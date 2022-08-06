using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Channels
{
    [TLObject(913655003)]
    public class TLRequestDeleteParticipantHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 913655003;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLAbsInputPeer Participant { get; set; }
        public TL.Messages.TLAffectedHistory Response { get; set; }


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
            ObjectUtils.SerializeObject(Channel, bw);
            ObjectUtils.SerializeObject(Participant, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);

        }
    }
}
