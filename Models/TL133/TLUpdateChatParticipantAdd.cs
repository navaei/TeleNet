using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1037718609)]
    public class TLUpdateChatParticipantAdd : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1037718609;
            }
        }

             public long ChatId {get;set;}
     public long UserId {get;set;}
     public long InviterId {get;set;}
     public int Date {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
UserId = br.ReadInt64();
InviterId = br.ReadInt64();
Date = br.ReadInt32();
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
bw.Write(UserId);
bw.Write(InviterId);
bw.Write(Date);
bw.Write(Version);

        }
    }
}
