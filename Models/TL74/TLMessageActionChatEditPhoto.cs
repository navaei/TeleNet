using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(2144015272)]
    public class TLMessageActionChatEditPhoto : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 2144015272;
            }
        }

        public TLAbsPhoto Photo { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Photo, bw);

        }
    }
}
