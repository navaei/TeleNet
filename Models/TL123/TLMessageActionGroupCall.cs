using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(2047704898)]
    public class TLMessageActionGroupCall : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 2047704898;
            }
        }

             public int Flags {get;set;}
     public TLInputGroupCall Call {get;set;}
     public int? Duration {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Duration != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
Duration = br.ReadInt32();
else
Duration = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(Call,bw);
if ((Flags & 1) != 0)
bw.Write(Duration.Value);

        }
    }
}
