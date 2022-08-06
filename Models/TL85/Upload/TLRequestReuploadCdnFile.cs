using System.IO;

namespace  TeleNet.Models.TL85.Upload
{
	[TLObject(-1691921240)]
    public class TLRequestReuploadCdnFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1691921240;
            }
        }

                public byte[] FileToken {get;set;}
        public byte[] RequestToken {get;set;}
public TLVector<TLFileHash> Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = BytesUtil.Deserialize(br);
RequestToken = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BytesUtil.Serialize(FileToken,bw);
BytesUtil.Serialize(RequestToken,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLFileHash>)ObjectUtils.DeserializeVector<TLFileHash>(br);

		}
    }
}
