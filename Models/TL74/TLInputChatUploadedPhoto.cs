using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1837345356)]
    public class TLInputChatUploadedPhoto : TLAbsInputChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return -1837345356;
            }
        }

        public TLAbsInputFile File { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(File, bw);

        }
    }
}
