using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1013621127)]
    public class TLRequestGetChats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1013621127;
            }
        }

        public TLVector<int> Id { get; set; }
        public TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsChats)ObjectUtils.DeserializeObject(br);

        }
    }
}
