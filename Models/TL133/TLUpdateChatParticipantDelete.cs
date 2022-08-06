using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-483443337)]
    public class TLUpdateChatParticipantDelete : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -483443337;
            }
        }

             public long ChatId {get;set;}
     public long UserId {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
UserId = br.ReadInt64();
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
bw.Write(UserId);
bw.Write(Version);

        }
    }
}
