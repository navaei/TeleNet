using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(236446268)]
    public class TLPhotoSizeEmpty : TLAbsPhotoSize
    {
        public override int Constructor
        {
            get
            {
                return 236446268;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Type = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Type, bw);

        }
    }
}
