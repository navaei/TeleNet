using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(215516896)]
    public class TLInvoice : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 215516896;
            }
        }

        public int Flags { get; set; }
        public bool Test { get; set; }
        public bool NameRequested { get; set; }
        public bool PhoneRequested { get; set; }
        public bool EmailRequested { get; set; }
        public bool ShippingAddressRequested { get; set; }
        public bool Flexible { get; set; }
        public bool PhoneToProvider { get; set; }
        public bool EmailToProvider { get; set; }
        public string Currency { get; set; }
        public TLVector<TLLabeledPrice> Prices { get; set; }
        public long? MaxTipAmount { get; set; }
        public TLVector<long> SuggestedTipAmounts { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Test ? (Flags | 1) : (Flags & ~1);
            Flags = NameRequested ? (Flags | 2) : (Flags & ~2);
            Flags = PhoneRequested ? (Flags | 4) : (Flags & ~4);
            Flags = EmailRequested ? (Flags | 8) : (Flags & ~8);
            Flags = ShippingAddressRequested ? (Flags | 16) : (Flags & ~16);
            Flags = Flexible ? (Flags | 32) : (Flags & ~32);
            Flags = PhoneToProvider ? (Flags | 64) : (Flags & ~64);
            Flags = EmailToProvider ? (Flags | 128) : (Flags & ~128);
            Flags = MaxTipAmount != null ? (Flags | 256) : (Flags & ~256);
            Flags = SuggestedTipAmounts != null ? (Flags | 256) : (Flags & ~256);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Test = (Flags & 1) != 0;
            NameRequested = (Flags & 2) != 0;
            PhoneRequested = (Flags & 4) != 0;
            EmailRequested = (Flags & 8) != 0;
            ShippingAddressRequested = (Flags & 16) != 0;
            Flexible = (Flags & 32) != 0;
            PhoneToProvider = (Flags & 64) != 0;
            EmailToProvider = (Flags & 128) != 0;
            Currency = StringUtil.Deserialize(br);
            Prices = (TLVector<TLLabeledPrice>)ObjectUtils.DeserializeVector<TLLabeledPrice>(br);
            if ((Flags & 256) != 0)
                MaxTipAmount = br.ReadInt64();
            else
                MaxTipAmount = null;

            if ((Flags & 256) != 0)
                SuggestedTipAmounts = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);
            else
                SuggestedTipAmounts = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Currency, bw);
            ObjectUtils.SerializeObject(Prices, bw);
            if ((Flags & 256) != 0)
                bw.Write(MaxTipAmount.Value);
            if ((Flags & 256) != 0)
                ObjectUtils.SerializeObject(SuggestedTipAmounts, bw);

        }
    }
}
