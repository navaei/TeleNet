using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(1347929239)]
    public class TLRequestUploadEncryptedFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1347929239;
            }
        }

                public TLInputEncryptedChat Peer {get;set;}
        public TLAbsInputEncryptedFile File {get;set;}
        public TLAbsEncryptedFile Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLInputEncryptedChat)ObjectUtils.DeserializeObject(br);
File = (TLAbsInputEncryptedFile)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(File,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsEncryptedFile)ObjectUtils.DeserializeObject(br);

		}
    }
}
