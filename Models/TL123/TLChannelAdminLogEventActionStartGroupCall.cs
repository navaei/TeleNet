using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(589338437)]
    public class TLChannelAdminLogEventActionStartGroupCall : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 589338437;
            }
        }

             public TLInputGroupCall Call {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call,bw);

        }
    }
}
