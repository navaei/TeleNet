using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-468280483)]
    public class TLBotInfo : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -468280483;
            }
        }

             public long UserId {get;set;}
     public string Description {get;set;}
     public TLVector<TLBotCommand> Commands {get;set;}
     public TLAbsBotMenuButton MenuButton {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Description = StringUtil.Deserialize(br);
Commands = (TLVector<TLBotCommand>)ObjectUtils.DeserializeVector<TLBotCommand>(br);
MenuButton = (TLAbsBotMenuButton)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
StringUtil.Serialize(Description,bw);
ObjectUtils.SerializeObject(Commands,bw);
ObjectUtils.SerializeObject(MenuButton,bw);

        }
    }
}
