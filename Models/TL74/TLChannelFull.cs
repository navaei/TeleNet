using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1991201921)]
    public class TLChannelFull : TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return 1991201921;
            }
        }

             public int Flags {get;set;}
     public bool CanViewParticipants {get;set;}
     public bool CanSetUsername {get;set;}
     public bool CanSetStickers {get;set;}
     public bool HiddenPrehistory {get;set;}
     public int Id {get;set;}
     public string About {get;set;}
     public int? ParticipantsCount {get;set;}
     public int? AdminsCount {get;set;}
     public int? KickedCount {get;set;}
     public int? BannedCount {get;set;}
     public int ReadInboxMaxId {get;set;}
     public int ReadOutboxMaxId {get;set;}
     public int UnreadCount {get;set;}
     public TLAbsPhoto ChatPhoto {get;set;}
     public TLPeerNotifySettings NotifySettings {get;set;}
     public TLAbsExportedChatInvite ExportedInvite {get;set;}
     public TLVector<TLBotInfo> BotInfo {get;set;}
     public int? MigratedFromChatId {get;set;}
     public int? MigratedFromMaxId {get;set;}
     public int? PinnedMsgId {get;set;}
     public TLStickerSet Stickerset {get;set;}
     public int? AvailableMinId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
CanViewParticipants = (Flags & 8) != 0;
CanSetUsername = (Flags & 64) != 0;
CanSetStickers = (Flags & 128) != 0;
HiddenPrehistory = (Flags & 1024) != 0;
Id = br.ReadInt32();
About = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
ParticipantsCount = br.ReadInt32();
else
ParticipantsCount = null;

if ((Flags & 2) != 0)
AdminsCount = br.ReadInt32();
else
AdminsCount = null;

if ((Flags & 4) != 0)
KickedCount = br.ReadInt32();
else
KickedCount = null;

if ((Flags & 4) != 0)
BannedCount = br.ReadInt32();
else
BannedCount = null;

ReadInboxMaxId = br.ReadInt32();
ReadOutboxMaxId = br.ReadInt32();
UnreadCount = br.ReadInt32();
ChatPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
NotifySettings = (TLPeerNotifySettings)ObjectUtils.DeserializeObject(br);
ExportedInvite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
BotInfo = (TLVector<TLBotInfo>)ObjectUtils.DeserializeVector<TLBotInfo>(br);
if ((Flags & 16) != 0)
MigratedFromChatId = br.ReadInt32();
else
MigratedFromChatId = null;

if ((Flags & 16) != 0)
MigratedFromMaxId = br.ReadInt32();
else
MigratedFromMaxId = null;

if ((Flags & 32) != 0)
PinnedMsgId = br.ReadInt32();
else
PinnedMsgId = null;

if ((Flags & 256) != 0)
Stickerset = (TLStickerSet)ObjectUtils.DeserializeObject(br);
else
Stickerset = null;

if ((Flags & 512) != 0)
AvailableMinId = br.ReadInt32();
else
AvailableMinId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);




bw.Write(Id);
StringUtil.Serialize(About,bw);
if ((Flags & 1) != 0)
bw.Write(ParticipantsCount.Value);
if ((Flags & 2) != 0)
bw.Write(AdminsCount.Value);
if ((Flags & 4) != 0)
bw.Write(KickedCount.Value);
if ((Flags & 4) != 0)
bw.Write(BannedCount.Value);
bw.Write(ReadInboxMaxId);
bw.Write(ReadOutboxMaxId);
bw.Write(UnreadCount);
ObjectUtils.SerializeObject(ChatPhoto,bw);
ObjectUtils.SerializeObject(NotifySettings,bw);
ObjectUtils.SerializeObject(ExportedInvite,bw);
ObjectUtils.SerializeObject(BotInfo,bw);
if ((Flags & 16) != 0)
bw.Write(MigratedFromChatId.Value);
if ((Flags & 16) != 0)
bw.Write(MigratedFromMaxId.Value);
if ((Flags & 32) != 0)
bw.Write(PinnedMsgId.Value);
if ((Flags & 256) != 0)
ObjectUtils.SerializeObject(Stickerset,bw);
if ((Flags & 512) != 0)
bw.Write(AvailableMinId.Value);

        }
    }
}
