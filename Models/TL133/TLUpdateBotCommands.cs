using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1299263278)]
    public class TLUpdateBotCommands : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1299263278;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public long BotId {get;set;}
     public TLVector<TLBotCommand> Commands {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
BotId = br.ReadInt64();
Commands = (TLVector<TLBotCommand>)ObjectUtils.DeserializeVector<TLBotCommand>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(BotId);
ObjectUtils.SerializeObject(Commands,bw);

        }
    }
}
