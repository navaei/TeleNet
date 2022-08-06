using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(2137295719)]
    public class TLSearchResultPosition : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 2137295719;
            }
        }

             public int MsgId {get;set;}
     public int Date {get;set;}
     public int Offset {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt32();
Date = br.ReadInt32();
Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MsgId);
bw.Write(Date);
bw.Write(Offset);

        }
    }
}
