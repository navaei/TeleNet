using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1147422299)]
    public class TLUpdatePeerHistoryTTL : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1147422299;
            }
        }

             public int Flags {get;set;}
     public TLAbsPeer Peer {get;set;}
     public int? TtlPeriod {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = TtlPeriod != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
TtlPeriod = br.ReadInt32();
else
TtlPeriod = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 1) != 0)
bw.Write(TtlPeriod.Value);

        }
    }
}
