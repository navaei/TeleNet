using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
	[TLObject(-275956116)]
    public class TLAffectedFoundMessages : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -275956116;
            }
        }

             public int Pts {get;set;}
     public int PtsCount {get;set;}
     public int Offset {get;set;}
     public TLVector<int> Messages {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Pts = br.ReadInt32();
PtsCount = br.ReadInt32();
Offset = br.ReadInt32();
Messages = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Pts);
bw.Write(PtsCount);
bw.Write(Offset);
ObjectUtils.SerializeObject(Messages,bw);

        }
    }
}
