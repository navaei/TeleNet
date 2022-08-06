using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-2092401936)]
    public class TLUpdateChatUserTyping : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -2092401936;
            }
        }

             public long ChatId {get;set;}
     public TLAbsPeer FromId {get;set;}
     public TLAbsSendMessageAction Action {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Action = (TLAbsSendMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(FromId,bw);
ObjectUtils.SerializeObject(Action,bw);

        }
    }
}
