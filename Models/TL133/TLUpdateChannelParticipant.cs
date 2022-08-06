using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1738720581)]
    public class TLUpdateChannelParticipant : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1738720581;
            }
        }

             public int Flags {get;set;}
     public long ChannelId {get;set;}
     public int Date {get;set;}
     public long ActorId {get;set;}
     public long UserId {get;set;}
     public TLAbsChannelParticipant PrevParticipant {get;set;}
     public TLAbsChannelParticipant NewParticipant {get;set;}
     public TLAbsExportedChatInvite Invite {get;set;}
     public int Qts {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = PrevParticipant != null ? (Flags | 1) : (Flags & ~1);
Flags = NewParticipant != null ? (Flags | 2) : (Flags & ~2);
Flags = Invite != null ? (Flags | 4) : (Flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ChannelId = br.ReadInt64();
Date = br.ReadInt32();
ActorId = br.ReadInt64();
UserId = br.ReadInt64();
if ((Flags & 1) != 0)
PrevParticipant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
else
PrevParticipant = null;

if ((Flags & 2) != 0)
NewParticipant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
else
NewParticipant = null;

if ((Flags & 4) != 0)
Invite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
else
Invite = null;

Qts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(ChannelId);
bw.Write(Date);
bw.Write(ActorId);
bw.Write(UserId);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(PrevParticipant,bw);
if ((Flags & 2) != 0)
ObjectUtils.SerializeObject(NewParticipant,bw);
if ((Flags & 4) != 0)
ObjectUtils.SerializeObject(Invite,bw);
bw.Write(Qts);

        }
    }
}
