using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(1885586395)]
    public class TLUpdatePendingJoinRequests : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1885586395;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public int RequestsPending {get;set;}
     public TLVector<long> RecentRequesters {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
RequestsPending = br.ReadInt32();
RecentRequesters = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(RequestsPending);
ObjectUtils.SerializeObject(RecentRequesters,bw);

        }
    }
}
