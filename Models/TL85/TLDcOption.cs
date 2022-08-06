using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(414687501)]
    public class TLDcOption : TLAbsDcOption
    {
        public override int Constructor
        {
            get
            {
                return 414687501;
            }
        }

        public byte[] Secret { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Ipv6 ? (Flags | 1) : (Flags & ~1);
            Flags = MediaOnly ? (Flags | 2) : (Flags & ~2);
            Flags = TcpoOnly ? (Flags | 4) : (Flags & ~4);
            Flags = Cdn ? (Flags | 8) : (Flags & ~8);
            Flags = Static ? (Flags | 16) : (Flags & ~16);
            Flags = Secret != null ? (Flags | 1024) : (Flags & ~1024);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Ipv6 = (Flags & 1) != 0;
            MediaOnly = (Flags & 2) != 0;
            TcpoOnly = (Flags & 4) != 0;
            Cdn = (Flags & 8) != 0;
            Static = (Flags & 16) != 0;
            Id = br.ReadInt32();
            IpAddress = StringUtil.Deserialize(br);
            Port = br.ReadInt32();
            if ((Flags & 1024) != 0)
                Secret = BytesUtil.Deserialize(br);
            else
                Secret = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);





            bw.Write(Id);
            StringUtil.Serialize(IpAddress, bw);
            bw.Write(Port);
            if ((Flags & 1024) != 0)
                BytesUtil.Serialize(Secret, bw);

        }
    }
}
