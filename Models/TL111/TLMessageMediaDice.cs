using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(1670374507)]
    public class TLMessageMediaDice : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return 1670374507;
            }
        }

             public int Value {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Value = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Value);

        }
    }
}
