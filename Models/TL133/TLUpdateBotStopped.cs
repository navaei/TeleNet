using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-997782967)]
    public class TLUpdateBotStopped : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -997782967;
            }
        }

             public long UserId {get;set;}
     public int Date {get;set;}
     public bool Stopped {get;set;}
     public int Qts {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Date = br.ReadInt32();
Stopped = BoolUtil.Deserialize(br);
Qts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(Date);
BoolUtil.Serialize(Stopped,bw);
bw.Write(Qts);

        }
    }
}
