using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Phone
{
	[TLObject(-558650433)]
    public class TLRequestGetGroupCallStreamRtmpUrl : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -558650433;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public bool Revoke {get;set;}
public Phone.TLGroupCallStreamRtmpUrl Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Revoke = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
BoolUtil.Serialize(Revoke,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Phone.TLGroupCallStreamRtmpUrl)ObjectUtils.DeserializeObject(br);

		}
    }
}
