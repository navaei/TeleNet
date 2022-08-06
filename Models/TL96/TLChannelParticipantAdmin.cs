using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(1571450403)]
    public class TLChannelParticipantAdmin : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 1571450403;
            }
        }

             public int Flags {get;set;}
     public bool CanEdit {get;set;}
     public bool Self {get;set;}
     public int UserId {get;set;}
     public int? InviterId {get;set;}
     public int PromotedBy {get;set;}
     public int Date {get;set;}
     public TLChatAdminRights AdminRights {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = CanEdit ? (Flags | 1) : (Flags & ~1);
Flags = Self ? (Flags | 2) : (Flags & ~2);
Flags = InviterId != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
CanEdit = (Flags & 1) != 0;
Self = (Flags & 2) != 0;
UserId = br.ReadInt32();
if ((Flags & 2) != 0)
InviterId = br.ReadInt32();
else
InviterId = null;

PromotedBy = br.ReadInt32();
Date = br.ReadInt32();
AdminRights = (TLChatAdminRights)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


bw.Write(UserId);
if ((Flags & 2) != 0)
bw.Write(InviterId.Value);
bw.Write(PromotedBy);
bw.Write(Date);
ObjectUtils.SerializeObject(AdminRights,bw);

        }
    }
}
