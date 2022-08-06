using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(1873957073)]
    public class TLReactionCount : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1873957073;
            }
        }

             public int Flags {get;set;}
     public bool Chosen {get;set;}
     public string Reaction {get;set;}
     public int Count {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Chosen ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Chosen = (Flags & 1) != 0;
Reaction = StringUtil.Deserialize(br);
Count = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

StringUtil.Serialize(Reaction,bw);
bw.Write(Count);

        }
    }
}
