using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1502174430)]
    public class TLInputMessageID : TLAbsInputMessage
    {
        public override int Constructor
        {
            get
            {
                return -1502174430;
            }
        }

             public int Id {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
