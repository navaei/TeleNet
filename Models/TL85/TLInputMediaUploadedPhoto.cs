using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(505969924)]
    public class TLInputMediaUploadedPhoto : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 505969924;
            }
        }

             public int Flags {get;set;}
     public TLAbsInputFile File {get;set;}
     public TLVector<TLAbsInputDocument> Stickers {get;set;}
     public int? TtlSeconds {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Stickers != null ? (Flags | 1) : (Flags & ~1);
Flags = TtlSeconds != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
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
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Stickers,bw);
if ((Flags & 2) != 0)
bw.Write(TtlSeconds.Value);

        }
    }
}
