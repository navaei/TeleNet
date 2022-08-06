using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(85337187)]
    public class TLResPQ : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 85337187;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public string Pq {get;set;}
     public TLVector<long> ServerPublicKeyFingerprints {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
Pq = StringUtil.Deserialize(br);
ServerPublicKeyFingerprints = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
StringUtil.Serialize(Pq,bw);
ObjectUtils.SerializeObject(ServerPublicKeyFingerprints,bw);

        }
    }
}
