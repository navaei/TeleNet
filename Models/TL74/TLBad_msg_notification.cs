using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1477445615)]
    public class TLBad_msg_notification : TLAbsBadMsgNotification
    {
        public override int Constructor
        {
            get
            {
                return -1477445615;
            }
        }

        public long BadMsgId { get; set; }
        public int BadMsgSeqno { get; set; }
        public int ErrorCode { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            BadMsgId = br.ReadInt64();
            BadMsgSeqno = br.ReadInt32();
            ErrorCode = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(BadMsgId);
            bw.Write(BadMsgSeqno);
            bw.Write(ErrorCode);

        }
    }
}
