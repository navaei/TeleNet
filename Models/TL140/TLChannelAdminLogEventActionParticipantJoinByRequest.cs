using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-1347021750)]
    public class TLChannelAdminLogEventActionParticipantJoinByRequest : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return -1347021750;
            }
        }

             public TLAbsExportedChatInvite Invite {get;set;}
     public long ApprovedBy {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Invite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
ApprovedBy = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Invite,bw);
bw.Write(ApprovedBy);

        }
    }
}
