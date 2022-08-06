using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1934976362)]
    public class TLUpdateBotPrecheckoutQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1934976362;
            }
        }

             public int Flags {get;set;}
     public long QueryId {get;set;}
     public long UserId {get;set;}
     public byte[] Payload {get;set;}
     public TLPaymentRequestedInfo Info {get;set;}
     public string ShippingOptionId {get;set;}
     public string Currency {get;set;}
     public long TotalAmount {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Info != null ? (Flags | 1) : (Flags & ~1);
Flags = ShippingOptionId != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
QueryId = br.ReadInt64();
UserId = br.ReadInt64();
Payload = BytesUtil.Deserialize(br);
if ((Flags & 1) != 0)
Info = (TLPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
else
Info = null;

if ((Flags & 2) != 0)
ShippingOptionId = StringUtil.Deserialize(br);
else
ShippingOptionId = null;

Currency = StringUtil.Deserialize(br);
TotalAmount = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(QueryId);
bw.Write(UserId);
BytesUtil.Serialize(Payload,bw);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Info,bw);
if ((Flags & 2) != 0)
StringUtil.Serialize(ShippingOptionId,bw);
StringUtil.Serialize(Currency,bw);
bw.Write(TotalAmount);

        }
    }
}
