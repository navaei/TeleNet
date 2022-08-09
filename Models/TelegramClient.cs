using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Account;
using TeleNet.Models.TL.Auth;
using TeleNet.Models.TL.Channels;
using TeleNet.Models.TL.Contacts;
using TeleNet.Models.TL.Help;
using TeleNet.Models.TL.Messages;
using TeleNet.Models.TL.Upload;
using TeleNet.Models.Auth;
using TeleNet.Models.MTProto.Crypto;
using TeleNet.Models.Network;
using TeleNet.Models.Utils;
using TLRequestInvokeWithLayer = TeleNet.Models.TL.TLRequestInvokeWithLayer;
using TLRequestSearch = TeleNet.Models.TL.Contacts.TLRequestSearch;
using TLSendMessageTypingAction = TeleNet.Models.TL.TLSendMessageTypingAction;
using TLStickerSet = TeleNet.Models.TL.Messages.TLStickerSet;
using TLUser = TeleNet.Models.TL.TLUser;
using System.IO;

namespace TeleNet.Models
{
    public class TelegramClient : IDisposable
    {
        private MtProtoSender _sender;
        private AuthKey _key;
        private TcpTransport _transport;
        private string _apiHash = "";
        private int _apiId = 0;
        private Session _session;
        private List<TLAbsDcOption> dcOptions;
        private TcpClientConnectionHandler _handler;
        private const int ApiLayer = 140;

        public TelegramClient(int apiId, string apiHash,
            ISessionStore store = null, string sessionUserId = "session", TcpClientConnectionHandler handler = null, string connectionAddress = "",
            int port = Session.defaultConnectionPort)
        {
            if (apiId == default(int))
                throw new MissingApiConfigurationException("API_ID");
            if (string.IsNullOrEmpty(apiHash))
                throw new MissingApiConfigurationException("API_HASH");

            if (store == null)
                store = new FileSessionStore();

            _apiHash = apiHash;
            _apiId = apiId;
            _handler = handler;

            _session = Session.TryLoadOrCreateNew(store, sessionUserId, connectionAddress, port);
            _transport = new TcpTransport(_session.ServerAddress, _session.Port, _handler);
        }


        public async Task ConnectAsync(bool reconnect = false)
        {
            if (_session.AuthKey == null || reconnect)
            {
                var result = await Authenticator.DoAuthentication(_transport);
                _session.AuthKey = result.AuthKey;
                _session.TimeOffset = result.TimeOffset;
            }

            _sender = new MtProtoSender(_transport, _session);

            //set-up layer
            var config = new TLRequestGetConfig();
            var request = new TL123.TLRequestInitConnection()
            {
                ApiId = _apiId,
                AppVersion = "8.5",
                DeviceModel = "GenymobileSamsung Galaxy S10",
                LangCode = "en",
                SystemLangCode = "en-us",
                LangPack = "android",
                Query = config,
                SystemVersion = "SDK 29",
            };
            var invokewithLayer = new TLRequestInvokeWithLayer() { Layer = ApiLayer, Query = request };
            await _sender.Send(invokewithLayer);
            await _sender.Receive(invokewithLayer);

            dcOptions = ((TL99.TLConfig)invokewithLayer.Response).DcOptions.ToList();
        }

        private async Task ReconnectToDcAsync(int dcId, bool migration = false)
        {
            if (dcOptions == null || !dcOptions.Any())
                throw new InvalidOperationException($"Can't reconnect. Establish initial connection first.");

            TL133.Auth.TLExportedAuthorization exported = null;
            if (migration)
            {
                if (_session.TLUser != null)
                {
                    var exportAuthorization =
                        new TLRequestExportAuthorization() { DcId = dcId };
                    exported =
                        await SendRequestAsync<TL133.Auth.TLExportedAuthorization>(exportAuthorization);
                }
            }

            var dc = dcOptions.First(d => d.Id == dcId);

            _transport = new TcpTransport(dc.IpAddress, dc.Port, _handler);
            //_session = Session.TryLoadOrCreateNew(new MemorySessionStore(), _session.SessionUserId + "_mem", dc.IpAddress, dc.Port);
            _session.ServerAddress = dc.IpAddress;
            _session.Port = dc.Port;
            if (migration)
                _session.SetStore(new MemorySessionStore());

            await ConnectAsync(true);

            if (migration)
                if (_session.TLUser != null && exported != null)
                {
                    var importAuthorization = new TL133.Auth.TLRequestImportAuthorization() { Id = exported.Id, Bytes = exported.Bytes };
                    var imported = await SendRequestAsync<TL.Auth.TLAbsAuthorization>(importAuthorization);
                    OnUserAuthenticated(_session.TLUser);
                }
        }

        private async Task RequestWithDcMigration(TLMethod request, MtProtoSender sender = null)
        {
            if (sender != null)
                _sender = sender;

            if (_sender == null)
                throw new InvalidOperationException("Not connected!");

            var completed = false;
            while (!completed)
            {
                try
                {
                    await _sender.Send(request);
                    await _sender.Receive(request);
                    completed = true;
                }
                catch (UserMigrationException e)
                {
                    await ReconnectToDcAsync(e.DC);
                    // prepare the request for another try
                    request.ConfirmReceived = false;
                }
                catch (PhoneMigrationException e)
                {
                    await ReconnectToDcAsync(e.DC);
                    // prepare the request for another try
                    request.ConfirmReceived = false;
                }
                catch (DataCenterMigrationException e)
                {
                    throw e;
                }
            }
        }

        public bool IsUserAuthorized()
        {
            return _session.TLUser != null;
        }

        public async Task<bool> IsPhoneRegisteredAsync(string phoneNumber)
        {
            throw new NotImplementedException();

            //if (String.IsNullOrWhiteSpace(phoneNumber))
            //    throw new ArgumentNullException(nameof(phoneNumber));

            //var authCheckPhoneRequest = new TLRequestCheckPhone() { PhoneNumber = phoneNumber };

            //await RequestWithDcMigration(authCheckPhoneRequest);

            //return authCheckPhoneRequest.Response.PhoneRegistered;
        }

        public async Task<string> SendCodeRequestAsync(string phoneNumber)
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            var request = new TLRequestSendCode() { PhoneNumber = phoneNumber, ApiId = _apiId, ApiHash = _apiHash };

            await RequestWithDcMigration(request);

            return request.Response.PhoneCodeHash;
        }

        public async Task<TLAbsUser> MakeAuthAsync(string phoneNumber, string phoneCodeHash, string code)
        {
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            if (String.IsNullOrWhiteSpace(phoneCodeHash))
                throw new ArgumentNullException(nameof(phoneCodeHash));

            if (String.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            var request = new TLRequestSignIn()
            {
                PhoneNumber = phoneNumber,
                PhoneCodeHash = phoneCodeHash,
                PhoneCode = code
            };

            await RequestWithDcMigration(request);

            OnUserAuthenticated(request.Response.User);

            return request.Response.User;
        }

        public async Task<TLPassword> GetPasswordSetting()
        {
            var request = new TLRequestGetPassword();

            await RequestWithDcMigration(request);

            return ((TLPassword)request.Response);
        }

        public async Task<TLUser> MakeAuthWithPasswordAsync(TLPassword password, string password_str)
        {
            throw new NotImplementedException();

            //byte[] password_Bytes = Encoding.UTF8.GetBytes(password_str);
            //IEnumerable<byte> rv = password.CurrentSalt.Concat(password_Bytes).Concat(password.CurrentSalt);

            //SHA256Managed hashstring = new SHA256Managed();
            //var password_hash = hashstring.ComputeHash(rv.ToArray());

            //var request = new TLRequestCheckPassword() { PasswordHash = password_hash };

            //await RequestWithDcMigration(request);

            //OnUserAuthenticated(((TLUser)request.Response.User));

            //return ((TLUser)request.Response.User);
        }

        public async Task<TLUser> SignUpAsync(string phoneNumber, string phoneCodeHash, string code, string firstName, string lastName)
        {
            var request = new TLRequestSignUp()
            {
                PhoneNumber = phoneNumber,
                PhoneCode = code,
                PhoneCodeHash = phoneCodeHash,
                FirstName = firstName,
                LastName = lastName
            };

            await RequestWithDcMigration(request);

            OnUserAuthenticated(((TLUser)request.Response.User));

            return ((TLUser)request.Response.User);
        }

        public async Task<TLAbsUpdates> CreateChatAsync(string title, TLVector<TLAbsInputUser> users)
        {
            var request = new TLRequestCreateChat() { Users = users, Title = title };
            await RequestWithDcMigration(request);
            return request.Response;
        }

        public async Task<TLAbsUpdates> CreateChannelAsync(string title, string about = "")
        {
            var request =
                new TLRequestCreateChannel() { Title = title, About = about, Broadcast = true, Megagroup = false };
            await RequestWithDcMigration(request);
            return request.Response;
        }

        public async Task<bool> SetUsernameAsync(int channel, string username)
        {
            var request = new TL.Channels.TLRequestUpdateUsername()
            {
                Channel = new Models.TL.TLInputChannel() { ChannelId = channel },
                Username = username
            };

            await RequestWithDcMigration(request);
            return request.Response;
        }

        public async Task<TLAbsUpdates> AddUsersToChannelAsync(int channelId, TLVector<TLAbsInputUser> users)
        {
            var request = new TLRequestInviteToChannel();
            request.Users = users;
            request.Channel = new Models.TL.TLInputChannel() { ChannelId = channelId };
            await RequestWithDcMigration(request);
            return request.Response;
        }


        public async Task<T> SendRequestAsync<T>(TLMethod methodToExecute, MtProtoSender sender = null)
        {
            await RequestWithDcMigration(methodToExecute, sender);

            var result = methodToExecute.GetType().GetProperty("Response").GetValue(methodToExecute);

            return (T)result;
        }

        public async Task<TLContacts> GetContactsAsync()
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            var req = new TLRequestGetContacts() { Hash = 0 };

            return await SendRequestAsync<TLContacts>(req);
        }

        

        public async Task<TL.Messages.TLChatFull> GetFullChannelAsync(TLAbsInputChannel channel)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            var req = new TLRequestGetFullChannel() { Channel = channel };

            return await SendRequestAsync<TL.Messages.TLChatFull>(req);
        }

        public async Task<TeleNet.Models.TL.Messages.TLStickerSet> GetStickerSetAsync(TLAbsInputStickerSet stickerSet)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            var req = new TLRequestGetStickerSet()
            {
                Stickerset = stickerSet,
            };

            return await SendRequestAsync<TLStickerSet>(req);
        }

        public async Task<TLAbsUpdates> SendMessageAsync(TLAbsInputPeer peer, string message)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            return await SendRequestAsync<TLAbsUpdates>(
                   new TLRequestSendMessage()
                   {
                       Peer = peer,
                       Message = message,
                       RandomId = Helpers.GenerateRandomLong()
                   });
        }

        public async Task<Boolean> SendTypingAsync(TLAbsInputPeer peer)
        {
            var req = new TLRequestSetTyping()
            {
                Action = new TLSendMessageTypingAction(),
                Peer = peer
            };
            return await SendRequestAsync<Boolean>(req);
        }

        public async Task<TLAbsDialogs> GetUserDialogsAsync()
        {
            return await SendRequestAsync<TLAbsDialogs>(
                new TLRequestGetDialogs() { OffsetDate = 0, OffsetPeer = new TLInputPeerEmpty(), Limit = 100 });
        }

        public async Task<TLAbsDialogs> GetUserDialogs85Async()
        {
            return await SendRequestAsync<TLAbsDialogs>(
                new TL.Messages.TLRequestGetDialogs() { OffsetDate = 0, OffsetPeer = new TLInputPeerEmpty(), Limit = 100 });
        }

        public async Task<TLAbsUpdates> SendUploadedPhotoAsync(TLAbsInputPeer peer, TLAbsInputFile file, string caption)
        {
            return await SendRequestAsync<TLAbsUpdates>(new Models.TL111.Messages.TLRequestSendMedia()
            {
                RandomId = Helpers.GenerateRandomLong(),
                Background = false,
                ClearDraft = false,
                Message = caption,
                Media = new TLInputMediaUploadedPhoto() { File = file, },
                Peer = peer
            });
        }

        public async Task<TLAbsUpdates> SendUploadedDocument(
            TLAbsInputPeer peer, TLAbsInputFile file, string caption, string mimeType, TLVector<TLAbsDocumentAttribute> attributes, TLAbsInputFile thumb)
        {
            return await SendRequestAsync<TLAbsUpdates>(new Models.TL111.Messages.TLRequestSendMedia()
            {
                RandomId = Helpers.GenerateRandomLong(),
                Background = false,
                ClearDraft = false,
                Message = caption,
                Media = new TLInputMediaUploadedDocument()
                {
                    File = file,
                    MimeType = mimeType,
                    Attributes = attributes,
                    Thumb = thumb
                },
                Peer = peer,
            });
        }

        public async Task<TLFile> GetFile(TLAbsInputFileLocation location, int filePartSize, int offset = 0)
        {
            var requestGetFile = new TL111.Upload.TLRequestGetFile()
            {
                Location = location,
                Limit = filePartSize,
                Offset = offset,
            };

            TLAbsFile result;
            try
            {
                result = await SendRequestAsync<TLAbsFile>(requestGetFile);
                return result is TLFile tlFile78
                    ? new TLFile()
                    {
                        Bytes = tlFile78.Bytes,
                        Mtime = tlFile78.Mtime,
                        Type = tlFile78.Type
                    }
                    : (TLFile)result;
            }
            catch (FileMigrationException ex)
            {
                //Muti client not be supported
                await ReconnectToDcAsync(ex.DC, true);

                result = await SendRequestAsync<TLAbsFile>(requestGetFile);
                return result is TLFile tlFile78
                  ? new TLFile()
                  {
                      Bytes = tlFile78.Bytes,
                      Mtime = tlFile78.Mtime,
                      Type = tlFile78.Type
                  }
                  : (TLFile)result; ;
            }
        }

        private static TLRequestExportAuthorization GetRequestExportAuthorization(int dcId)
        {
            return new TeleNet.Models.TL.Auth.TLRequestExportAuthorization
            {
                DcId = dcId
            };
        }

        public async Task SendPingAsync()
        {
            await _sender.SendPingAsync();
        }

        public async Task<TLAbsMessages> GetHistoryAsync(TLAbsInputPeer peer, int offset, int max_id, int min_id, int limit)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            var req = new TLRequestGetHistory()
            {
                Peer = peer,
                AddOffset = offset,
                MaxId = max_id,
                MinId = min_id,
                Limit = limit
            };
            return await SendRequestAsync<TLAbsMessages>(req);
        }


        public async Task<bool> UpdateStatusAsync(bool offline)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            var req = new TLRequestUpdateStatus() { Offline = offline };
            return await SendRequestAsync<bool>(req);
        }

        /// <summary>
        /// Serch user or chat. API: contacts.search#11f812d8 q:string limit:int = contacts.Found;
        /// </summary>
        /// <param name="q">User or chat name</param>
        /// <param name="limit">Max result count</param>
        /// <returns></returns>
        public async Task<TLFound> SearchUserAsync(string q, int limit = 10)
        {
            var r = new TLRequestSearch
            {
                Q = q,
                Limit = limit
            };

            return await SendRequestAsync<TLFound>(r);
        }

        public async Task<TLAbsInputFile> UploadFile(string name, StreamReader reader)
        {
            const long tenMb = 10 * 1024 * 1024;
            return await UploadFile(name, reader, reader.BaseStream.Length >= tenMb);
        }

        public bool IsConnected
        {
            get
            {
                if (_transport == null)
                    return false;
                return _transport.IsConnected;
            }
        }

        private static string GetFileHash(byte[] data)
        {
            string md5_checksum;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                var hashResult = new StringBuilder(hash.Length * 2);

                foreach (byte t in hash)
                    hashResult.Append(t.ToString("x2"));

                md5_checksum = hashResult.ToString();
            }

            return md5_checksum;
        }

        private static byte[] GetFile(StreamReader reader)
        {
            var file = new byte[reader.BaseStream.Length];

            using (reader)
            {
                reader.BaseStream.Read(file, 0, (int)reader.BaseStream.Length);
            }

            return file;
        }

        private static Queue<byte[]> GetFileParts(byte[] file)
        {
            var fileParts = new Queue<byte[]>();

            const int maxFilePart = 512 * 1024;

            using (var stream = new MemoryStream(file))
            {
                while (stream.Position != stream.Length)
                {
                    if ((stream.Length - stream.Position) > maxFilePart)
                    {
                        var temp = new byte[maxFilePart];
                        stream.Read(temp, 0, maxFilePart);
                        fileParts.Enqueue(temp);
                    }
                    else
                    {
                        var length = stream.Length - stream.Position;
                        var temp = new byte[length];
                        stream.Read(temp, 0, (int)(length));
                        fileParts.Enqueue(temp);
                    }
                }
            }

            return fileParts;
        }

        private async Task<TLAbsInputFile> UploadFile(string name, StreamReader reader, bool isBigFileUpload)
        {
            var file = GetFile(reader);
            var fileParts = GetFileParts(file);

            int partNumber = 0;
            int partsCount = fileParts.Count;
            long file_id = BitConverter.ToInt64(Helpers.GenerateRandomBytes(8), 0);
            while (fileParts.Count != 0)
            {
                var part = fileParts.Dequeue();

                if (isBigFileUpload)
                {
                    await SendRequestAsync<bool>(new TLRequestSaveBigFilePart
                    {
                        FileId = file_id,
                        FilePart = partNumber,
                        Bytes = part,
                        FileTotalParts = partsCount
                    });
                }
                else
                {
                    await SendRequestAsync<bool>(new TLRequestSaveFilePart
                    {
                        FileId = file_id,
                        FilePart = partNumber,
                        Bytes = part
                    });
                }
                partNumber++;
            }

            if (isBigFileUpload)
            {
                return new TLInputFileBig
                {
                    Id = file_id,
                    Name = name,
                    Parts = partsCount
                };
            }
            else
            {
                return new TLInputFile
                {
                    Id = file_id,
                    Name = name,
                    Parts = partsCount,
                    Md5Checksum = GetFileHash(file)
                };
            }
        }

        private void OnUserAuthenticated(TLAbsUser TLUser)
        {
            _session.TLUser = TLUser;
            _session.SessionExpires = int.MaxValue;

            _session.Save();
        }

        public void Dispose()
        {
            if (_transport != null)
            {
                _transport.Dispose();
                _transport = null;
            }
        }
    }
}
