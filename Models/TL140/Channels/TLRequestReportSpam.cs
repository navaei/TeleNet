using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Channels
{
	[TLObject(-196443371)]
    public class TLRequestReportSpam : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -196443371;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public TLAbsInputPeer Participant {get;set;}
        public TLVector<int> Id {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
Participant = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
ObjectUtils.SerializeObject(Participant,bw);
ObjectUtils.SerializeObject(Id,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
