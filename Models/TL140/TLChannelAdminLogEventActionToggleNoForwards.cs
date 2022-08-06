using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-886388890)]
    public class TLChannelAdminLogEventActionToggleNoForwards : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return -886388890;
            }
        }

             public bool NewValue {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            NewValue = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(NewValue,bw);

        }
    }
}
