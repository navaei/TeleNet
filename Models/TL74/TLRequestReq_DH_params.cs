using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(-686627650)]
    public class TLRequestReq_DH_params : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -686627650;
            }
        }

                public Int128 Nonce {get;set;}
        public Int128 ServerNonce {get;set;}
        public string P {get;set;}
        public string Q {get;set;}
        public long PublicKeyFingerprint {get;set;}
        public string EncryptedData {get;set;}
        public TLAbsServer_DH_Params Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
P = StringUtil.Deserialize(br);
Q = StringUtil.Deserialize(br);
PublicKeyFingerprint = br.ReadInt64();
EncryptedData = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
StringUtil.Serialize(P,bw);
StringUtil.Serialize(Q,bw);
bw.Write(PublicKeyFingerprint);
StringUtil.Serialize(EncryptedData,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsServer_DH_Params)ObjectUtils.DeserializeObject(br);

		}
    }
}
