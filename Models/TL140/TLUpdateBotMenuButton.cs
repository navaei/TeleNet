using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(347625491)]
    public class TLUpdateBotMenuButton : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 347625491;
            }
        }

             public long BotId {get;set;}
     public TLAbsBotMenuButton Button {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            BotId = br.ReadInt64();
Button = (TLAbsBotMenuButton)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(BotId);
ObjectUtils.SerializeObject(Button,bw);

        }
    }
}
