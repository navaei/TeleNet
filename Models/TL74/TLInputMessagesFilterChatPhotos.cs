using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(975236280)]
    public class TLInputMessagesFilterChatPhotos : TLAbsMessagesFilter
    {
        public override int Constructor
        {
            get
            {
                return 975236280;
            }
        }



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
    }
}
