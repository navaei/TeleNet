using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-595914432)]
    public class TLMessageEntityMentionName : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -595914432;
            }
        }

             public int Offset {get;set;}
     public int Length {get;set;}
     public long UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
Length = br.ReadInt32();
UserId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Offset);
bw.Write(Length);
bw.Write(UserId);

        }
    }
}
