using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1744710921)]
    public class TLDocumentAttributeHasStickers : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return -1744710921;
            }
        }

        

		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }
    }
}
