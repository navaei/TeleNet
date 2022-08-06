using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using TeleNet.Models.Utils;
using TeleNet.Models.TL;
using TeleNet.Models;

namespace TeleNet.OpenClient
{
    class Program
    {
        #region properties

        private static UpdaterConfig _updaterConfig;
        private static TelegramClient _client;
        private static TelegramClient _clientFile;
        private static Models.TL.Messages.TLAbsDialogs _dialogs;
        private static readonly int DownloadDocumentPartSize = 128 * 1024; // 128kb for document
        private static readonly int DownloadPhotoPartSize = 64 * 1024; // 64kb for photo
        private static int _floodErrorCount = 0;
        #endregion

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            var configuration = builder.Build();
            _updaterConfig = configuration.Get<UpdaterConfig>();

            //TLContext.Init();

            if (!string.IsNullOrEmpty(_updaterConfig.LocalProxy))
                WebRequest.DefaultWebProxy = new WebProxy(_updaterConfig.LocalProxy.Split(':')[0],
                    int.Parse(_updaterConfig.LocalProxy.Split(':')[1]));

            ConsoleLogger.Log("Enter phone number:");
            EnterPhoneNumber:
            var adminPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrEmpty(adminPhoneNumber))
            {
                if (adminPhoneNumber.Length < 8)
                {
                    ConsoleLogger.Log("Invalid phone number: Please enter a valid phone number like 989123338899 ");
                    goto EnterPhoneNumber;
                }

                adminPhoneNumber = adminPhoneNumber.Trim();
            }


            ConsoleLogger.Log("Starting login to telegram with " + adminPhoneNumber);

            try
            {
                var sessionNamePrefix = _updaterConfig.SessionName + "_" + adminPhoneNumber.Substring(adminPhoneNumber.Length - 5, 4);
                _client = await GetTlgClient(_updaterConfig.ApiHash, _updaterConfig.ApiId, sessionNamePrefix, adminPhoneNumber);

                //define multi client to support reconnect to new dc
                _clientFile = await GetTlgClient(_updaterConfig.ApiHash, _updaterConfig.ApiId, sessionNamePrefix + "_file", adminPhoneNumber);
            }
            catch (Exception e)
            {
                ConsoleLogger.Log("Global GetTlgClient " + e.GetInnerException().Message.SubstringX(300), ConsoleLogger.LogType.Error);
                goto End;
            }

            Start:
            var command = string.Empty;
            try
            {
                Console.Write("Enter Command:");
                command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    throw new Exception("Invalid Command");
                }

                if (command.ToLower() == "getsticker")
                {
                    Console.Write("StickerSet Id:");
                    var stickerStr = Console.ReadLine();
                    ulong stickersetId;
                    TeleNet.Models.TL.Messages.TLStickerSet stickerset;
                    if (ulong.TryParse(stickerStr, out stickersetId))
                    {
                        Console.Write("StickerSet Accesshash:");
                        var accesshash = ulong.Parse(Console.ReadLine());
                        ConsoleLogger.Log("Getting sticker...");
                        stickerset = await DownloadStickerSetAsync(accesshash, stickersetId);
                    }
                    else
                    {
                        //get dice sticker by emojiicon
                        if (stickerStr.StartsWith("c_"))
                            stickerStr = ((char)int.Parse(stickerStr.Replace("c_", ""))).ToString();
                        stickerset = await DownloadStickerSetAsync(0, 0, stickerStr.Length < 4 ? null : stickerStr,
                            stickerStr.Length < 4 ? stickerStr : null);
                    }

                    ConsoleLogger.Log("Save sticker set " + stickerset.Set.Id + " docs:" + stickerset.Documents.Count);
                }
                else if (command.ToLower() == "getchannel")
                {
                    Console.Write("Channel username:");
                    var messageCount = await GetChannelFiles(Console.ReadLine(), 10);
                    ConsoleLogger.Log("Channel message count:" + messageCount, ConsoleLogger.LogType.SupperInfo);
                }
                else if (command.ToLower() == "getthemes")
                {
                    var themes = GetThemes("android", 0).Result;
                }
                else
                {
                    throw new Exception("Invalid Command");
                }
            }
            catch (Exception e)
            {
                try
                {
                    ConsoleLogger.Log(e.GetInnerException().Message.SubstringX(300));
                }
                catch (Exception)
                {
                    //ignore
                }
            }

            ConsoleLogger.Log("Finish.\t Start again:start \t Exit:any keys");
            var cmd = Console.ReadLine();
            if (cmd != null && cmd.ToLower() == "start")
                goto Start;

            End:
            ConsoleLogger.Log("Finish!");
            Environment.Exit(1);
        }

        private static async Task<TelegramClient> GetTlgClient(string apiHash, int apiId, string sessionName, string mainPhoneNumber,
            Models.Network.TcpClientConnectionHandler clientConnectionHandler = null)
        {
            var phoneCodeHash = string.Empty;

            var client = new TelegramClient(apiId, apiHash, null, sessionName, clientConnectionHandler);

            authenticated:
            ConsoleLogger.Log("Connecting...");
            var task = Task.Factory.StartNew(() => { client.ConnectAsync().Wait(); });

            ConsoleLogger.Log("MakeAuthentication");
            if (!task.Wait(TimeSpan.FromMinutes(1)))
            {
                await MakeAuthentication(client, mainPhoneNumber);
            }

            ConsoleLogger.Log("Connected");
            if (!client.IsUserAuthorized())
            {
                ConsoleLogger.Log("User not autorized");
                if (string.IsNullOrEmpty(phoneCodeHash))
                {
                    try
                    {
                        phoneCodeHash = await client.SendCodeRequestAsync(mainPhoneNumber);
                        goto authenticated;
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetInnerException().Message.Contains("Password"))
                        {
                            client.MakeAuthWithPasswordAsync(new Models.TL.Account.TLPassword(), "").Wait();
                        }
                        else
                            throw;
                    }

                }

                ConsoleLogger.Log($"Enter login code{(sessionName.EndsWith("file") ? "(file)" : "")}:");
                var authCode = Console.ReadLine();
                var user = await client.MakeAuthAsync(mainPhoneNumber, phoneCodeHash, authCode);
                ConsoleLogger.Log("Login successfull.");
            }

            return client;
        }

        private static async Task MakeAuthentication(TelegramClient client, string mainPhoneNumber)
        {
            var hash = await client.SendCodeRequestAsync(mainPhoneNumber);
            ConsoleLogger.Log("waiting for code");
            var code = Console.ReadLine();
            var user = await client.MakeAuthAsync(mainPhoneNumber, hash, code);
            if (!client.IsUserAuthorized())
            {
                hash = await client.SendCodeRequestAsync(mainPhoneNumber);
                ConsoleLogger.Log("please try again.add code");
                code = Console.ReadLine();
                user = await client.MakeAuthAsync(mainPhoneNumber, hash, code);
            }

        }

        private static async Task<int> GetChannelFiles(string username, int limit)
        {
            if (_floodErrorCount > 2)
            {
                ConsoleLogger.Log("Max Flood Count " + _floodErrorCount, ConsoleLogger.LogType.SupperInfo);
                return 0;
            }

            ConsoleLogger.Log($"Get channel's files.... @{username} limit:{limit}");
            GETDIALOGS:
            try
            {
                _dialogs = await _client.GetUserDialogs85Async();
            }
            catch (Exception exception)
            {
                if (exception.GetInnerException()
                            .Message.Contains("Flood prevention"))
                {
                    ConsoleLogger.Log("GetChannelFiles Dialogs Floood " + exception.GetInnerException().Message.SubstringX(300), ConsoleLogger.LogType.Error);
                    await Task.Delay(TimeSpan.FromSeconds(45));
                    _floodErrorCount++;
                    return -1;
                }

                throw;
            }

            var chats = _dialogs is Models.TL.Messages.TLDialogs tlDialogs ? tlDialogs.Chats : ((Models.TL.Messages.TLDialogsSlice)_dialogs).Chats;
            //ConsoleLogger.Log("Chats count:" + chats.Count);

            if (username[0] == '@')
                username = username.Remove(0, 1);

            //----Get Validation Code---
            //var userTemp = (Models.TL.TLUser)(_dialogs as TLDialogs).Users.SingleOrDefault(c => c is Models.TL.TLUser && ((Models.TL.TLUser)c).Id == 777000);
            //var hssss = _client.GetHistoryAsync(new Models.TL.TLInputPeerUser()
            //{
            //    UserId = (int)userTemp.Id,
            //    AccessHash = userTemp.AccessHash.Value
            //}, 0, 0,  0, 10).Result;

            var channel = (Models.TL133.TLChannel)chats.FirstOrDefault(i => i is Models.TL133.TLChannel ch && string.Equals(i.Username, username,
                                                   StringComparison.CurrentCultureIgnoreCase));

            if (channel == null)
            {
                var found = await _client.SearchUserAsync("@" + username);
                if (found.Chats.Any())
                {
                    var channely = found.Chats.FirstOrDefault(c => c is Models.TL133.TLChannel chl &&
                      chl.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

                    if (channely != null)
                    {
                        var channelId = (Models.TL133.TLChannel)channely;
                        var updates = await _client.SendRequestAsync<TLAbsUpdates>(new Models.TL.Channels.TLRequestJoinChannel()
                        {
                            Channel = new TLInputChannel() { AccessHash = channelId.AccessHash.Value, ChannelId = (int)channelId.Id }
                        });

                        if (updates is Models.TL.TLUpdates || updates is Models.TL.TLUpdates)
                        {
                            ConsoleLogger.Log("Join to channel " + channelId.Username, ConsoleLogger.LogType.SupperInfo);
                            goto GETDIALOGS;
                        }
                    }
                    else
                    {
                        ConsoleLogger.Log("OpenClient ChannelNotFound " + username, ConsoleLogger.LogType.Warning);
                    }
                }

                throw new Exception("Channel " + username + " not found. You must join to channel first");
            }

            ConsoleLogger.Log("Get channel posts. @" + channel.Username + " ChannelId:" + channel.Id, ConsoleLogger.LogType.Info);
            var histories = await _client.GetHistoryAsync(new TLInputPeerChannel()
            {
                ChannelId = (int)channel.Id,
                AccessHash = channel.AccessHash.Value
            }, 0, 0,/* LastItemId*/ 0, limit);

            Models.TL140.TLMessage message = null;
            var messages = ((Models.TL123.Messages.TLChannelMessages)histories).Messages
                .OfType<Models.TL140.TLMessage>()
                .ToList();
            messages = messages.OrderBy(m => m.Id).ToList();
            var errorCount = 0;
            for (var index = 0; index < messages.Count; index++)
            {
                message = messages[index];
                Console.WriteLine("Get message " + message.Id + " " + message.Message.SubstringX(50));
                try
                {

                    if (message.Media != null)
                    {
                        if (message.Media is TLMessageMediaPhoto photo)
                        {
                            Console.Write("Download photo: " + photo.Photo.Id);
                        }
                        else if (message.Media is TLMessageMediaDocument document1 &&
                                 document1.Document is Models.TL123.TLDocument stickerDoc && (stickerDoc.MimeType == "image/webp" || stickerDoc.MimeType == "application/x-tgsticker") &&
                                 ((TLDocumentAttributeSticker)stickerDoc.Attributes.First(a => a is TLDocumentAttributeSticker)).Stickerset is TLInputStickerSetID stickerPack)
                        {
                            ConsoleLogger.Log(string.Format("Sticker ID:{0} AH:{1} ",
                                stickerPack.Id, stickerPack.AccessHash), ConsoleLogger.LogType.Info, false, false);
                        }
                        else if (message.Media is TLMessageMediaDocument document)
                        {
                            ConsoleLogger.Log(string.Format("Document ID:{0} MimeType:{1} ",
                                document.Document.Id, document.Document.MimeType), ConsoleLogger.LogType.Info, false, false);

                        }
                        else if (message.Media is TLMessageMediaWebPage mediaWebPage && mediaWebPage.Webpage is TLAbsWebPage webpage)
                        {
                            ConsoleLogger.Log(string.Format("WebPage ID:{0} DisplayUrl:{1} ", webpage.Id, webpage.DisplayUrl),
                                ConsoleLogger.LogType.Info, false, false);
                        }
                        else if (message.Media is Models.TL123.TLMessageMediaDice mediaDic)
                        {

                        }
                        else
                        {
                            ConsoleLogger.Log(" This media was not support ", ConsoleLogger.LogType.Default, false, false);
                            continue;
                        }
                    }

                    if (message.Entities != null && message.Entities.Any())
                    {

                    }
                }
                catch (Exception exception)
                {
                    var addionional = "";
                    ConsoleLogger.Log("Error count:" + errorCount + " " + addionional + "\n" +
                        exception.GetInnerException().Message.SubstringX(350) + " ", ConsoleLogger.LogType.Error);

                    if (exception.GetInnerException().Message.Contains("Flood prevention. Telegram now requires your program"))
                    {
                        await Task.Delay(TimeSpan.FromMinutes(1));
                        _floodErrorCount++;
                        index--;
                        break;
                    }

                    errorCount++;
                }
            }

            ConsoleLogger.Log("Get channel messages was done! Last:" + message.Id + " Messages Count:" + messages.Count + " ErrorCount:" + errorCount + " ------");
            return messages.Count;
        }


        private static async Task<Models.TL.Messages.TLStickerSet> GetStickerSet(ulong accessHash, ulong stickerSetId)
        {
            var stickerset = await _client.GetStickerSetAsync(new TLInputStickerSetID()
            {
                AccessHash = (long)accessHash,
                Id = (long)stickerSetId
            });

            //ConsoleLogger.Log(string.Format("Sticker info {0} {1} {2} {3}", stickerset.Set.Id, stickerset.Set.Count,
            //    stickerset.Set.Title, stickerset.Set.ShortName));
            return stickerset;
        }

        private static async Task<Models.TL.Messages.TLStickerSet> GetStickerSet(Models.TL.TLAbsInputStickerSet stickerSet)
        {
            var stickerset = await _client.GetStickerSetAsync(stickerSet);

            //ConsoleLogger.Log(string.Format("Sticker info {0} {1} {2} {3}", stickerset.Set.Id, stickerset.Set.Count,
            //    stickerset.Set.Title, stickerset.Set.ShortName));
            return stickerset;
        }

        private static async Task<TeleNet.Models.TL.Messages.TLStickerSet> DownloadStickerSetAsync(ulong accessHash, ulong stickerSetId,
            string stickerSetName = null, string emojiIcon = null)
        {
            var sticker = !string.IsNullOrEmpty(stickerSetName) ? await GetStickerSet(new Models.TL.TLInputStickerSetShortName
            {
                ShortName = stickerSetName
            }) : !string.IsNullOrEmpty(emojiIcon) ?
                await GetStickerSet(new Models.TL123.TLInputStickerSetDice()
                {
                    Emoticon = emojiIcon
                }) :
                    await GetStickerSet(new TLInputStickerSetID()
                    {
                        AccessHash = (long)accessHash,
                        Id = (long)stickerSetId
                    });

            foreach (var pack in sticker.Packs)
            {
                ConsoleLogger.Debug("Pack:" + pack.Emoticon);
            }

            ConsoleLogger.Log("sticker.Documents " + sticker.Documents.Count);
            foreach (var document in sticker.Documents)
            {
                ConsoleLogger.Debug("Sticker Doc:" + document.Id);
            }

            ConsoleLogger.Log("Download sticker successfully");
            return sticker;
        }

        private async Task<byte[]> GetDocumentFile(long fileid, long accesshash, int size)
        {
            var filePart = 512 * 1024;
            var offset = 0;
            using (var ms = new MemoryStream())
            {
                while (offset < size)
                {
                    try
                    {
                        var resFile = await _clientFile.GetFile(
                                new TLInputDocumentFileLocation()
                                {
                                    Id = fileid,
                                    AccessHash = accesshash
                                }, filePart, offset);

                        ms.Write(resFile.Bytes, 0, resFile.Bytes.Length);
                        offset += filePart;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return ms.ToArray();

            }
        }

        private static async Task<byte[]> GetDocumentFile(long fileid, long accesshash, byte[] fileReference, string thumbSize = null)
        {
            var filePartSize = DownloadDocumentPartSize;

            var offset = 0;
            var bytes = new List<byte>();
            while (true)
            {
                var file = await _clientFile.GetFile(!string.IsNullOrEmpty(thumbSize) ?
                    new Models.TL99.TLInputDocumentFileLocation()
                    {
                        Id = fileid,
                        AccessHash = accesshash,
                        FileReference = fileReference,
                        ThumbSize = thumbSize
                    } : (TLAbsInputFileLocation)new Models.TL96.TLInputDocumentFileLocation()
                    {
                        Id = fileid,
                        AccessHash = accesshash,
                        FileReference = fileReference,
                    }, filePartSize, offset);
                if (file == null)
                {
                    return null;
                }

                bytes.AddRange(file.Bytes);
                if (file.Bytes.Length < filePartSize)
                {
                    return bytes.ToArray();
                }

                offset += file.Bytes.Length;
            }
        }

        private static async Task<byte[]> GetFile(long secret, int localid, long volumeid, byte[] fileReference, string thumbSize = null)
        {
            var filePartSize = DownloadPhotoPartSize;

            var location = string.IsNullOrEmpty(thumbSize) ?
                   fileReference != null ?
                   (TLAbsInputFileLocation)new Models.TL96.TLInputFileLocation()
                   {
                       Secret = secret,
                       LocalId = localid,
                       VolumeId = volumeid,
                       FileReference = fileReference
                   } : (TLAbsInputFileLocation)new Models.TL.TLInputFileLocation
                   {
                       Secret = secret,
                       LocalId = localid,
                       VolumeId = volumeid,
                   } :
               new Models.TL99.TLInputPhotoFileLocation()
               {
                   Id = volumeid,
                   AccessHash = secret,
                   FileReference = fileReference,
                   ThumbSize = thumbSize
               };

            var offset = 0;
            var bytes = new List<byte>();
            while (true)
            {
                var file = await _clientFile.GetFile(location, filePartSize, offset);

                if (file == null)
                {
                    return null;
                }

                bytes.AddRange(file.Bytes);
                if (file.Bytes.Length < filePartSize)
                {
                    return bytes.ToArray();
                }

                offset += file.Bytes.Length;
            }
        }


        private static async Task<Models.TL.Account.TLAbsThemes> GetThemes(string format, int hash)
        {
            return await _client.SendRequestAsync<Models.TL.Account.TLAbsThemes>(
                new Models.TL133.Account.TLRequestGetThemes() { Format = format, Hash = hash });
        }

    }
}
