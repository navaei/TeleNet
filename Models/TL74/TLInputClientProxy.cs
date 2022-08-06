using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1968737087)]
    public class TLInputClientProxy : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1968737087;
            }
        }

             public string Address {get;set;}
     public int Port {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Address = StringUtil.Deserialize(br);
Port = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Address,bw);
bw.Write(Port);

        }
    }
}
