using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1558266229)]
    public class TLPopularContact : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1558266229;
            }
        }

             public long ClientId {get;set;}
     public int Importers {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ClientId = br.ReadInt64();
Importers = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ClientId);
bw.Write(Importers);

        }
    }
}
