using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(470789295)]
    public class TLChannelParticipantBanned : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 470789295;
            }
        }

             public int Flags {get;set;}
     public bool Left {get;set;}
     public int UserId {get;set;}
     public int KickedBy {get;set;}
     public int Date {get;set;}
     public TLChatBannedRights BannedRights {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Left ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Left = (Flags & 1) != 0;
UserId = br.ReadInt32();
KickedBy = br.ReadInt32();
Date = br.ReadInt32();
BannedRights = (TLChatBannedRights)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(UserId);
bw.Write(KickedBy);
bw.Write(Date);
ObjectUtils.SerializeObject(BannedRights,bw);

        }
    }
}
