using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-901375139)]
    public class TLPeerLocated : TLAbsPeerLocated
    {
        public override int Constructor
        {
            get
            {
                return -901375139;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public int Expires {get;set;}
     public int Distance {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Expires = br.ReadInt32();
Distance = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Expires);
bw.Write(Distance);

        }
    }
}
