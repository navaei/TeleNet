using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
	[TLObject(-2095414366)]
    public class TLRequestUploadRingtone : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2095414366;
            }
        }

                public TLAbsInputFile File {get;set;}
        public string FileName {get;set;}
        public string MimeType {get;set;}
public TLAbsDocument Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
FileName = StringUtil.Deserialize(br);
MimeType = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
StringUtil.Serialize(FileName,bw);
StringUtil.Serialize(MimeType,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsDocument)ObjectUtils.DeserializeObject(br);

		}
    }
}
