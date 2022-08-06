using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Account
{
	[TLObject(473805619)]
    public class TLRequestUploadTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 473805619;
            }
        }

                public int Flags {get;set;}
        public TLAbsInputFile File {get;set;}
        public TLAbsInputFile Thumb {get;set;}
        public string FileName {get;set;}
        public string MimeType {get;set;}
public TLAbsDocument Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Thumb != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
Thumb = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
else
Thumb = null;

FileName = StringUtil.Deserialize(br);
MimeType = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(File,bw);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Thumb,bw);
StringUtil.Serialize(FileName,bw);
StringUtil.Serialize(MimeType,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsDocument)ObjectUtils.DeserializeObject(br);

		}
    }
}
