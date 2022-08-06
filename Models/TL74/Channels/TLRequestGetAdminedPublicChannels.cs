using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(-1920105769)]
    public class TLRequestGetAdminedPublicChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1920105769;
            }
        }

        public TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsChats)ObjectUtils.DeserializeObject(br);

        }
    }
}
