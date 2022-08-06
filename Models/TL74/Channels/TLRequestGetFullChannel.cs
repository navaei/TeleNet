using System.IO;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(141781513)]
    public class TLRequestGetFullChannel : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 141781513;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public Messages.TLChatFull Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLChatFull)ObjectUtils.DeserializeObject(br);

        }
    }
}
