using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL100.Messages
{
	[TLObject(-398136321)]
    public class TLSearchCounter : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -398136321;
            }
        }

             public int Flags {get;set;}
     public bool Inexact {get;set;}
     public TLAbsMessagesFilter Filter {get;set;}
     public int Count {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Inexact ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Inexact = (Flags & 2) != 0;
Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
Count = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Filter,bw);
bw.Write(Count);

        }
    }
}
