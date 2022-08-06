using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Channels
{
	[TLObject(-1599378234)]
    public class TLRequestGetParticipant : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1599378234;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public TLAbsInputPeer Participant {get;set;}
public Channels.TLChannelParticipant Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
Participant = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
ObjectUtils.SerializeObject(Participant,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Channels.TLChannelParticipant)ObjectUtils.DeserializeObject(br);

		}
    }
}
