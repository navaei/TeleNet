using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-1387279939)]
    public class TLMessageInteractionCounters : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1387279939;
            }
        }

             public int MsgId {get;set;}
     public int Views {get;set;}
     public int Forwards {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt32();
Views = br.ReadInt32();
Forwards = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MsgId);
bw.Write(Views);
bw.Write(Forwards);

        }
    }
}
