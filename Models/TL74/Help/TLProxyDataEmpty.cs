using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(-526508104)]
    public class TLProxyDataEmpty : TLAbsProxyData
    {
        public override int Constructor
        {
            get
            {
                return -526508104;
            }
        }

             public int Expires {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Expires);

        }
    }
}
