using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(1530447553)]
    public class TLInputMediaUploadedDocument : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 1530447553;
            }
        }

             public int Flags {get;set;}
     public bool NosoundVideo {get;set;}
     public TLAbsInputFile File {get;set;}
     public TLAbsInputFile Thumb {get;set;}
     public string MimeType {get;set;}
     public TLVector<TLAbsDocumentAttribute> Attributes {get;set;}
     public TLVector<TLAbsInputDocument> Stickers {get;set;}
     public int? TtlSeconds {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = NosoundVideo ? (Flags | 8) : (Flags & ~8);
Flags = Thumb != null ? (Flags | 4) : (Flags & ~4);
Flags = Stickers != null ? (Flags | 1) : (Flags & ~1);
Flags = TtlSeconds != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
NosoundVideo = (Flags & 8) != 0;
File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
if ((Flags & 4) != 0)
Thumb = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
else
Thumb = null;

MimeType = StringUtil.Deserialize(br);
Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);
if ((Flags & 1) != 0)
Stickers = (TLVector<TLAbsInputDocument>)ObjectUtils.DeserializeVector<TLAbsInputDocument>(br);
else
Stickers = null;

if ((Flags & 2) != 0)
TtlSeconds = br.ReadInt32();
else
TtlSeconds = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(File,bw);
if ((Flags & 4) != 0)
ObjectUtils.SerializeObject(Thumb,bw);
StringUtil.Serialize(MimeType,bw);
ObjectUtils.SerializeObject(Attributes,bw);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Stickers,bw);
if ((Flags & 2) != 0)
bw.Write(TtlSeconds.Value);

        }
    }
}
