using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-682079097)]
    public class TLStatsGroupTopAdmin : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -682079097;
            }
        }

             public long UserId {get;set;}
     public int Deleted {get;set;}
     public int Kicked {get;set;}
     public int Banned {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Deleted = br.ReadInt32();
Kicked = br.ReadInt32();
Banned = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(Deleted);
bw.Write(Kicked);
bw.Write(Banned);

        }
    }
}
