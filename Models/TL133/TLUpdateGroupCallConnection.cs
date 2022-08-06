using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(192428418)]
    public class TLUpdateGroupCallConnection : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 192428418;
            }
        }

             public int Flags {get;set;}
     public bool Presentation {get;set;}
     public TLDataJSON Params {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Presentation ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Presentation = (Flags & 1) != 0;
Params = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Params,bw);

        }
    }
}
