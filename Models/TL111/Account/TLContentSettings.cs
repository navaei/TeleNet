using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Account
{
	[TLObject(1474462241)]
    public class TLContentSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1474462241;
            }
        }

             public int Flags {get;set;}
     public bool SensitiveEnabled {get;set;}
     public bool SensitiveCanChange {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = SensitiveEnabled ? (Flags | 1) : (Flags & ~1);
Flags = SensitiveCanChange ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
SensitiveEnabled = (Flags & 1) != 0;
SensitiveCanChange = (Flags & 2) != 0;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);



        }
    }
}
