using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96.Contacts
{
	[TLObject(269745566)]
    public class TLRequestDeleteByPhones : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 269745566;
            }
        }

                public TLVector<string> Phones {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Phones = (TLVector<string>)ObjectUtils.DeserializeVector<string>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Phones,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
