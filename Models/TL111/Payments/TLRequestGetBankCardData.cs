using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Payments
{
	[TLObject(779736953)]
    public class TLRequestGetBankCardData : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 779736953;
            }
        }

                public string Number {get;set;}
public Payments.TLBankCardData Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Number = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Number,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Payments.TLBankCardData)ObjectUtils.DeserializeObject(br);

		}
    }
}
