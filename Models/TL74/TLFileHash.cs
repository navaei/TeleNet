using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1648543603)]
    public class TLFileHash : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1648543603;
            }
        }

             public int Offset {get;set;}
     public int Limit {get;set;}
     public byte[] Hash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
Limit = br.ReadInt32();
Hash = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Offset);
bw.Write(Limit);
BytesUtil.Serialize(Hash,bw);

        }
    }
}
