using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(-78455655)]
    public class TLInputMediaDocumentExternal : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -78455655;
            }
        }

             public int Flags {get;set;}
     public string Url {get;set;}
     public int? TtlSeconds {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = TtlSeconds != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Url = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
TtlSeconds = br.ReadInt32();
else
TtlSeconds = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
StringUtil.Serialize(Url,bw);
if ((Flags & 1) != 0)
bw.Write(TtlSeconds.Value);

        }
    }
}
