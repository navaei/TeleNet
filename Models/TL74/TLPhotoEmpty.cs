using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(590459437)]
    public class TLPhotoEmpty : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return 590459437;
            }
        }

		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
