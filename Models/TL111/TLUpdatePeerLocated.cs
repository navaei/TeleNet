using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-1263546448)]
    public class TLUpdatePeerLocated : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1263546448;
            }
        }

             public TLVector<TLAbsPeerLocated> Peers {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peers = (TLVector<TLAbsPeerLocated>)ObjectUtils.DeserializeVector<TLAbsPeerLocated>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peers,bw);

        }
    }
}
