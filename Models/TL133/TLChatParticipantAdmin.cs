using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1600962725)]
    public class TLChatParticipantAdmin : TLAbsChatParticipant
    {
        public override int Constructor
        {
            get
            {
                return -1600962725;
            }
        }

             public long UserId {get;set;}
     public long InviterId {get;set;}
     public int Date {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
InviterId = br.ReadInt64();
Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(InviterId);
bw.Write(Date);

        }
    }
}
