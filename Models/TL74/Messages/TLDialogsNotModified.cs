using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(-253500010)]
    public class TLDialogsNotModified : TLAbsDialogs
    {
        public override int Constructor
        {
            get
            {
                return -253500010;
            }
        }

             public int Count {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Count);

        }
    }
}
