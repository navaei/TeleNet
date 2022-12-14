using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(1786671974)]
    public class TLUpdatePeerSettings : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1786671974;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public TLPeerSettings Settings {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Settings = (TLPeerSettings)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(Settings,bw);

        }
    }
}
