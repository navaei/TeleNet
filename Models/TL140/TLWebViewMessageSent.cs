using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(211046684)]
    public class TLWebViewMessageSent : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 211046684;
            }
        }

             public int Flags {get;set;}
     public TLInputBotInlineMessageID MsgId {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = MsgId != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
MsgId = (TLInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
else
MsgId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(MsgId,bw);

        }
    }
}
