using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(630664139)]
    public class TLSendMessageEmojiInteraction : TLAbsSendMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 630664139;
            }
        }

             public string Emoticon {get;set;}
     public int MsgId {get;set;}
     public TLDataJSON Interaction {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);
MsgId = br.ReadInt32();
Interaction = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Emoticon,bw);
bw.Write(MsgId);
ObjectUtils.SerializeObject(Interaction,bw);

        }
    }
}
