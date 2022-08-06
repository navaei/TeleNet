using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-519864430)]
    public class TLMessageActionChatMigrateTo : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -519864430;
            }
        }

             public long ChannelId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);

        }
    }
}
