using System.IO;

namespace  TeleNet.Models.TL85.Upload
{
	[TLObject(1302676017)]
    public class TLRequestGetCdnFileHashes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1302676017;
            }
        }

                public byte[] FileToken {get;set;}
        public int Offset {get;set;}
public TLVector<TLFileHash> Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = BytesUtil.Deserialize(br);
Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BytesUtil.Serialize(FileToken,bw);
bw.Write(Offset);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLFileHash>)ObjectUtils.DeserializeVector<TLFileHash>(br);

		}
    }
}
