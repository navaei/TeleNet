using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Messages
{
	[TLObject(-1379669976)]
    public class TLRequestEditInlineBotMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1379669976;
            }
        }

                public int Flags {get;set;}
        public bool NoWebpage {get;set;}
        public bool StopGeoLive {get;set;}
        public TLInputBotInlineMessageID Id {get;set;}
        public string Message {get;set;}
        public TLAbsInputMedia Media {get;set;}
        public TLAbsReplyMarkup ReplyMarkup {get;set;}
        public TLVector<TLAbsMessageEntity> Entities {get;set;}
        public TLAbsInputGeoPoint GeoPoint {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = NoWebpage ? (Flags | 2) : (Flags & ~2);
Flags = StopGeoLive ? (Flags | 4096) : (Flags & ~4096);
Flags = Message != null ? (Flags | 2048) : (Flags & ~2048);
Flags = Media != null ? (Flags | 16384) : (Flags & ~16384);
Flags = ReplyMarkup != null ? (Flags | 4) : (Flags & ~4);
Flags = Entities != null ? (Flags | 8) : (Flags & ~8);
Flags = GeoPoint != null ? (Flags | 8192) : (Flags & ~8192);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
NoWebpage = (Flags & 2) != 0;
StopGeoLive = (Flags & 4096) != 0;
Id = (TLInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
if ((Flags & 2048) != 0)
Message = StringUtil.Deserialize(br);
else
Message = null;

if ((Flags & 16384) != 0)
Media = (TLAbsInputMedia)ObjectUtils.DeserializeObject(br);
else
Media = null;

if ((Flags & 4) != 0)
ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
else
ReplyMarkup = null;

if ((Flags & 8) != 0)
Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
else
Entities = null;

if ((Flags & 8192) != 0)
GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
else
GeoPoint = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


ObjectUtils.SerializeObject(Id,bw);
if ((Flags & 2048) != 0)
StringUtil.Serialize(Message,bw);
if ((Flags & 16384) != 0)
ObjectUtils.SerializeObject(Media,bw);
if ((Flags & 4) != 0)
ObjectUtils.SerializeObject(ReplyMarkup,bw);
if ((Flags & 8) != 0)
ObjectUtils.SerializeObject(Entities,bw);
if ((Flags & 8192) != 0)
ObjectUtils.SerializeObject(GeoPoint,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
