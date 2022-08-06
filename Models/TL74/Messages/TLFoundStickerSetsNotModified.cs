using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(223655517)]
    public class TLFoundStickerSetsNotModified : TLAbsFoundStickerSets
    {
        public override int Constructor
        {
            get
            {
                return 223655517;
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
