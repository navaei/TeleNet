using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-646342540)]
    public class TLInputMediaInvoice : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -646342540;
            }
        }

             public int Flags {get;set;}
     public string Title {get;set;}
     public string Description {get;set;}
     public TLInputWebDocument Photo {get;set;}
     public TLInvoice Invoice {get;set;}
     public byte[] Payload {get;set;}
     public string Provider {get;set;}
     public TLDataJSON ProviderData {get;set;}
     public string StartParam {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Photo != null ? (Flags | 1) : (Flags & ~1);
Flags = StartParam != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Title = StringUtil.Deserialize(br);
Description = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
Photo = (TLInputWebDocument)ObjectUtils.DeserializeObject(br);
else
Photo = null;

Invoice = (TLInvoice)ObjectUtils.DeserializeObject(br);
Payload = BytesUtil.Deserialize(br);
Provider = StringUtil.Deserialize(br);
ProviderData = (TLDataJSON)ObjectUtils.DeserializeObject(br);
if ((Flags & 2) != 0)
StartParam = StringUtil.Deserialize(br);
else
StartParam = null;


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
ObjectUtils.SerializeObject(Invoice,bw);
BytesUtil.Serialize(Payload,bw);
StringUtil.Serialize(Provider,bw);
ObjectUtils.SerializeObject(ProviderData,bw);
if ((Flags & 2) != 0)
StringUtil.Serialize(StartParam,bw);

        }
    }
}
