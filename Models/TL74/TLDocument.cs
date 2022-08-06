using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-2027738169)]
    public class TLDocument : TLAbsDocument
    {
        public override int Constructor
        {
            get
            {
                return -2027738169;
            }
        }

        public int Version { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Date = br.ReadInt32();
            MimeType = StringUtil.Deserialize(br);
            Size = br.ReadInt32();
            Thumb = (TLAbsPhotoSize)ObjectUtils.DeserializeObject(br);
            DcId = br.ReadInt32();
            Version = br.ReadInt32();
            Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
            bw.Write(AccessHash);
            bw.Write(Date);
            StringUtil.Serialize(MimeType, bw);
            bw.Write(Size);
            ObjectUtils.SerializeObject(Thumb, bw);
            bw.Write(DcId);
            bw.Write(Version);
            ObjectUtils.SerializeObject(Attributes, bw);

        }
    }
}
