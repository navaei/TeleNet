using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(755087855)]
    public class TLRequestResetWebAuthorization : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 755087855;
            }
        }

                public long Hash {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
