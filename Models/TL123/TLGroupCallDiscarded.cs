using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(2004925620)]
    public class TLGroupCallDiscarded : TLAbsGroupCall
    {
        public override int Constructor
        {
            get
            {
                return 2004925620;
            }
        }

             public long Id {get;set;}
     public long AccessHash {get;set;}
     public int Duration {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
AccessHash = br.ReadInt64();
Duration = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(AccessHash);
bw.Write(Duration);

        }
    }
}
