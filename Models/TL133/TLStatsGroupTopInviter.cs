using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1398765469)]
    public class TLStatsGroupTopInviter : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1398765469;
            }
        }

             public long UserId {get;set;}
     public int Invitations {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Invitations = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(Invitations);

        }
    }
}
