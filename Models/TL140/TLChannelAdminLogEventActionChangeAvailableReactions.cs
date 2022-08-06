using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-1661470870)]
    public class TLChannelAdminLogEventActionChangeAvailableReactions : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return -1661470870;
            }
        }

             public TLVector<string> PrevValue {get;set;}
     public TLVector<string> NewValue {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PrevValue = (TLVector<string>)ObjectUtils.DeserializeVector<string>(br);
NewValue = (TLVector<string>)ObjectUtils.DeserializeVector<string>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(PrevValue,bw);
ObjectUtils.SerializeObject(NewValue,bw);

        }
    }
}
