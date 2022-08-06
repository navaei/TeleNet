using System.IO;

namespace TeleNet.Models.TL.Account
{
	[TLObject(1304052993)]
    public class TLTakeout : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1304052993;
            }
        }

             public long Id {get;set;}


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
