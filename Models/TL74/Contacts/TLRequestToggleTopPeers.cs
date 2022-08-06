using System.IO;

namespace TeleNet.Models.TL.Contacts
{
	[TLObject(-2062238246)]
    public class TLRequestToggleTopPeers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2062238246;
            }
        }

                public bool Enabled {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Enabled = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(Enabled,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
