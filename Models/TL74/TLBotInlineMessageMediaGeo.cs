using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(982505656)]
    public class TLBotInlineMessageMediaGeo : TLAbsBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return 982505656;
            }
        }

        public int Flags { get; set; }
        public TLAbsGeoPoint Geo { get; set; }
        public TLAbsReplyMarkup ReplyMarkup { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ReplyMarkup != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
            else
                ReplyMarkup = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Geo, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ReplyMarkup, bw);

        }
    }
}
