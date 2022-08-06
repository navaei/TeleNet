using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Messages
{
	[TLObject(-241247891)]
    public class TLRequestGetDialogFilters : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -241247891;
            }
        }

        public TLVector<TLDialogFilter> Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLDialogFilter>)ObjectUtils.DeserializeVector<TLDialogFilter>(br);

		}
    }
}
