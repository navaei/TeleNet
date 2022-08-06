using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1441072131)]
    public class TLMessageActionSetMessagesTTL : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1441072131;
            }
        }

             public int Period {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Period = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Period);

        }
    }
}
