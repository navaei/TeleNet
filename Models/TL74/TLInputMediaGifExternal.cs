using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1212395773)]
    public class TLInputMediaGifExternal : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 1212395773;
            }
        }

             public string Url {get;set;}
     public string Q {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
Q = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
StringUtil.Serialize(Q,bw);

        }
    }
}
