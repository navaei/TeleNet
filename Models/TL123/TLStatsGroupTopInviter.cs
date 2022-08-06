using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(831924812)]
    public class TLStatsGroupTopInviter : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 831924812;
            }
        }

             public int UserId {get;set;}
     public int Invitations {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
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
