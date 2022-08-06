using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1436466797)]
    public class TLMessageFwdHeader : TLAbsMessageFwdHeader
    {
        public override int Constructor
        {
            get
            {
                return 1436466797;
            }
        }

             public int Flags {get;set;}
     public int? FromId {get;set;}
     public int Date {get;set;}
     public int? ChannelId {get;set;}
     public int? ChannelPost {get;set;}
     public string PostAuthor {get;set;}
     public TLAbsPeer SavedFromPeer {get;set;}
     public int? SavedFromMsgId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
FromId = br.ReadInt32();
else
FromId = null;

Date = br.ReadInt32();
if ((Flags & 2) != 0)
ChannelId = br.ReadInt32();
else
ChannelId = null;

if ((Flags & 4) != 0)
ChannelPost = br.ReadInt32();
else
ChannelPost = null;

if ((Flags & 8) != 0)
PostAuthor = StringUtil.Deserialize(br);
else
PostAuthor = null;

if ((Flags & 16) != 0)
SavedFromPeer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
else
SavedFromPeer = null;

if ((Flags & 16) != 0)
SavedFromMsgId = br.ReadInt32();
else
SavedFromMsgId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);
if ((Flags & 1) != 0)
bw.Write(FromId.Value);
bw.Write(Date);
if ((Flags & 2) != 0)
bw.Write(ChannelId.Value);
if ((Flags & 4) != 0)
bw.Write(ChannelPost.Value);
if ((Flags & 8) != 0)
StringUtil.Serialize(PostAuthor,bw);
if ((Flags & 16) != 0)
ObjectUtils.SerializeObject(SavedFromPeer,bw);
if ((Flags & 16) != 0)
bw.Write(SavedFromMsgId.Value);

        }
    }
}
