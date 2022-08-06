using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1048537159)]
    public class TLChannelAdminLogEventActionParticipantVolume : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 1048537159;
            }
        }

             public TLGroupCallParticipant Participant {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Participant = (TLGroupCallParticipant)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Participant,bw);

        }
    }
}
