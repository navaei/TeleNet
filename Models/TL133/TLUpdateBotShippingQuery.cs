using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1246823043)]
    public class TLUpdateBotShippingQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1246823043;
            }
        }

             public long QueryId {get;set;}
     public long UserId {get;set;}
     public byte[] Payload {get;set;}
     public TLPostAddress ShippingAddress {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            QueryId = br.ReadInt64();
UserId = br.ReadInt64();
Payload = BytesUtil.Deserialize(br);
ShippingAddress = (TLPostAddress)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(QueryId);
bw.Write(UserId);
BytesUtil.Serialize(Payload,bw);
ObjectUtils.SerializeObject(ShippingAddress,bw);

        }
    }
}
