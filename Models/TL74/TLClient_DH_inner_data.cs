using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(1715713620)]
    public class TLClient_DH_inner_data : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1715713620;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public long RetryId {get;set;}
     public string GB {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
RetryId = br.ReadInt64();
GB = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
bw.Write(RetryId);
StringUtil.Serialize(GB,bw);

        }
    }
}
