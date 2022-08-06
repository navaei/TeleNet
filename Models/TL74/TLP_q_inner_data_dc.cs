using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(-1443537003)]
    public class TLP_q_inner_data_dc : TLAbsP_Q_inner_data
    {
        public override int Constructor
        {
            get
            {
                return -1443537003;
            }
        }

             public string Pq {get;set;}
     public string P {get;set;}
     public string Q {get;set;}
     public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public Int256 NewNonce {get;set;}
     public int Dc {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Pq = StringUtil.Deserialize(br);
P = StringUtil.Deserialize(br);
Q = StringUtil.Deserialize(br);
Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
NewNonce = (Int256)ObjectUtils.DeserializeObject(br);
Dc = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Pq,bw);
StringUtil.Serialize(P,bw);
StringUtil.Serialize(Q,bw);
ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
ObjectUtils.SerializeObject(NewNonce,bw);
bw.Write(Dc);

        }
    }
}
