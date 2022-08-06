using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1937192669)]
    public class TLUpdateChannelUserTyping : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1937192669;
            }
        }

             public int Flags {get;set;}
     public long ChannelId {get;set;}
     public int? TopMsgId {get;set;}
     public TLAbsPeer FromId {get;set;}
     public TLAbsSendMessageAction Action {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = TopMsgId != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ChannelId = br.ReadInt64();
if ((Flags & 1) != 0)
TopMsgId = br.ReadInt32();
else
TopMsgId = null;

FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Action = (TLAbsSendMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(ChannelId);
if ((Flags & 1) != 0)
bw.Write(TopMsgId.Value);
ObjectUtils.SerializeObject(FromId,bw);
ObjectUtils.SerializeObject(Action,bw);

        }
    }
}
