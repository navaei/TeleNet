using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-837994576)]
    public class TLPageBlockAnchor : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return -837994576;
            }
        }

             public string Name {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Name = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Name,bw);

        }
    }
}
