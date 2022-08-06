using System.IO;

namespace TeleNet.Models.TL.Upload
{
	[TLObject(-956147407)]
    public class TLRequestGetFileHashes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -956147407;
            }
        }

                public TLAbsInputFileLocation Location {get;set;}
        public int Offset {get;set;}
        public TLVector<TLFileHash> Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Location = (TLAbsInputFileLocation)ObjectUtils.DeserializeObject(br);
Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Location,bw);
bw.Write(Offset);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLFileHash>)ObjectUtils.DeserializeVector<TLFileHash>(br);

		}
    }
}
