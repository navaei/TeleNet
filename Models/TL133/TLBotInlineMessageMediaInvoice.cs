using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(894081801)]
    public class TLBotInlineMessageMediaInvoice : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 894081801;
            }
        }

             public int Flags {get;set;}
     public bool ShippingAddressRequested {get;set;}
     public bool Test {get;set;}
     public string Title {get;set;}
     public string Description {get;set;}
     public TLAbsWebDocument Photo {get;set;}
     public string Currency {get;set;}
     public long TotalAmount {get;set;}
     public TLAbsReplyMarkup ReplyMarkup {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = ShippingAddressRequested ? (Flags | 2) : (Flags & ~2);
Flags = Test ? (Flags | 8) : (Flags & ~8);
Flags = Photo != null ? (Flags | 1) : (Flags & ~1);
Flags = ReplyMarkup != null ? (Flags | 4) : (Flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ShippingAddressRequested = (Flags & 2) != 0;
Test = (Flags & 8) != 0;
Title = StringUtil.Deserialize(br);
Description = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
Photo = (TLAbsWebDocument)ObjectUtils.DeserializeObject(br);
else
Photo = null;

Currency = StringUtil.Deserialize(br);
TotalAmount = br.ReadInt64();
if ((Flags & 4) != 0)
ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
else
ReplyMarkup = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


StringUtil.Serialize(Title,bw);
StringUtil.Serialize(Description,bw);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Photo,bw);
StringUtil.Serialize(Currency,bw);
bw.Write(TotalAmount);
if ((Flags & 4) != 0)
ObjectUtils.SerializeObject(ReplyMarkup,bw);

        }
    }
}
