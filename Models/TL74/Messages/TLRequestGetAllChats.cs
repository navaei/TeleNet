using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-341307408)]
    public class TLRequestGetAllChats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -341307408;
            }
        }

        public TLVector<int> ExceptIds { get; set; }
        public TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ExceptIds = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(ExceptIds, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsChats)ObjectUtils.DeserializeObject(br);

        }
    }
}
