using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(343859772)]
    public class TLSearchResultsCalendar : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 343859772;
            }
        }

             public int Flags {get;set;}
     public bool Inexact {get;set;}
     public int Count {get;set;}
     public int MinDate {get;set;}
     public int MinMsgId {get;set;}
     public int? OffsetIdOffset {get;set;}
     public TLVector<TLSearchResultsCalendarPeriod> Periods {get;set;}
     public TLVector<TLAbsMessage> Messages {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Inexact ? (Flags | 1) : (Flags & ~1);
Flags = OffsetIdOffset != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Inexact = (Flags & 1) != 0;
Count = br.ReadInt32();
MinDate = br.ReadInt32();
MinMsgId = br.ReadInt32();
if ((Flags & 2) != 0)
OffsetIdOffset = br.ReadInt32();
else
OffsetIdOffset = null;

Periods = (TLVector<TLSearchResultsCalendarPeriod>)ObjectUtils.DeserializeVector<TLSearchResultsCalendarPeriod>(br);
Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeVector<TLAbsMessage>(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(Count);
bw.Write(MinDate);
bw.Write(MinMsgId);
if ((Flags & 2) != 0)
bw.Write(OffsetIdOffset.Value);
ObjectUtils.SerializeObject(Periods,bw);
ObjectUtils.SerializeObject(Messages,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
