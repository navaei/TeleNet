using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-674602590)]
    public class TLUpdateChatParticipantAdmin : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -674602590;
            }
        }

             public long ChatId {get;set;}
     public long UserId {get;set;}
     public bool IsAdmin {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
UserId = br.ReadInt64();
IsAdmin = BoolUtil.Deserialize(br);
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
bw.Write(UserId);
BoolUtil.Serialize(IsAdmin,bw);
bw.Write(Version);

        }
    }
}
