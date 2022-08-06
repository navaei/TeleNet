using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(573315206)]
    public class TLChannelParticipantBanned : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 573315206;
            }
        }

             public int Flags {get;set;}
     public bool Left {get;set;}
     public int UserId {get;set;}
     public int KickedBy {get;set;}
     public int Date {get;set;}
     public TLChannelBannedRights BannedRights {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Left = (Flags & 1) != 0;
UserId = br.ReadInt32();
KickedBy = br.ReadInt32();
Date = br.ReadInt32();
BannedRights = (TLChannelBannedRights)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);

bw.Write(UserId);
bw.Write(KickedBy);
bw.Write(Date);
ObjectUtils.SerializeObject(BannedRights,bw);

        }
    }
}
