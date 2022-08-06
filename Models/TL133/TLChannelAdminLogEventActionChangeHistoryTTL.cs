using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1855199800)]
    public class TLChannelAdminLogEventActionChangeHistoryTTL : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 1855199800;
            }
        }

             public int PrevValue {get;set;}
     public int NewValue {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PrevValue = br.ReadInt32();
NewValue = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(PrevValue);
bw.Write(NewValue);

        }
    }
}
