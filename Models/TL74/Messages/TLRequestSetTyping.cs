using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1551737264)]
    public class TLRequestSetTyping : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1551737264;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLAbsSendMessageAction Action { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Action = (TLAbsSendMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Action, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
