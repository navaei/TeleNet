using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(176122811)]
    public class TLRequestGetChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 176122811;
            }
        }

        public TLVector<TLAbsInputChannel> Id { get; set; }
        public TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLVector<TLAbsInputChannel>)ObjectUtils.DeserializeVector<TLAbsInputChannel>(br);

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
