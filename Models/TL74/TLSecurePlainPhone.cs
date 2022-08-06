using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(2103482845)]
    public class TLSecurePlainPhone : TLAbsSecurePlainData
    {
        public override int Constructor
        {
            get
            {
                return 2103482845;
            }
        }

             public string Phone {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Phone = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Phone,bw);

        }
    }
}
