using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(1178116716)]
    public class TLUpdateReadChannelDiscussionOutbox : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1178116716;
            }
        }

             public int ChannelId {get;set;}
     public int TopMsgId {get;set;}
     public int ReadMaxId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt32();
TopMsgId = br.ReadInt32();
ReadMaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);
bw.Write(TopMsgId);
bw.Write(ReadMaxId);

        }
    }
}
