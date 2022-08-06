using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1940093419)]
    public class TLHighScore : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1940093419;
            }
        }

             public int Pos {get;set;}
     public long UserId {get;set;}
     public int Score {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Pos = br.ReadInt32();
UserId = br.ReadInt64();
Score = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Pos);
bw.Write(UserId);
bw.Write(Score);

        }
    }
}
