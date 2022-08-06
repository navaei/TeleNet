using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(2009052699)]
    public class TLPhotoSize : TLAbsPhotoSize
    {
        public override int Constructor
        {
            get
            {
                return 2009052699;
            }
        }

        public int Size { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Type = StringUtil.Deserialize(br);
            Location = (TLAbsFileLocation)ObjectUtils.DeserializeObject(br);
            W = br.ReadInt32();
            H = br.ReadInt32();
            Size = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Type, bw);
            ObjectUtils.SerializeObject(Location, bw);
            bw.Write(W);
            bw.Write(H);
            bw.Write(Size);

        }
    }
}
