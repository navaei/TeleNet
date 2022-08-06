using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(925204121)]
    public class TLInputPeerPhotoFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 925204121;
            }
        }

             public int Flags {get;set;}
     public bool Big {get;set;}
     public TLAbsInputPeer Peer {get;set;}
     public long PhotoId {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Big ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Big = (Flags & 1) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
PhotoId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
bw.Write(PhotoId);

        }
    }
}
