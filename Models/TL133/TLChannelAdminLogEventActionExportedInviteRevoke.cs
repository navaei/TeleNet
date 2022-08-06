using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1091179342)]
    public class TLChannelAdminLogEventActionExportedInviteRevoke : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 1091179342;
            }
        }

             public TLAbsExportedChatInvite Invite {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Invite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Invite,bw);

        }
    }
}
