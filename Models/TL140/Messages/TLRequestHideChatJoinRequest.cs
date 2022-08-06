using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(2145904661)]
    public class TLRequestHideChatJoinRequest : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2145904661;
            }
        }

                public int Flags {get;set;}
        public bool Approved {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public TLAbsInputUser UserId {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Approved ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Approved = (Flags & 1) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(UserId,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
