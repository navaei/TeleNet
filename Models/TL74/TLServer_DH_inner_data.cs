using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(-1249309254)]
    public class TLServer_DH_inner_data : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1249309254;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public int G {get;set;}
     public string DhPrime {get;set;}
     public string GA {get;set;}
     public int ServerTime {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
G = br.ReadInt32();
DhPrime = StringUtil.Deserialize(br);
GA = StringUtil.Deserialize(br);
ServerTime = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
bw.Write(G);
StringUtil.Serialize(DhPrime,bw);
StringUtil.Serialize(GA,bw);
bw.Write(ServerTime);

        }
    }
}
