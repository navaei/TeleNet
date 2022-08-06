using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(558156313)]
    public class TLRpc_error : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 558156313;
            }
        }

             public int ErrorCode {get;set;}
     public string ErrorMessage {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ErrorCode = br.ReadInt32();
ErrorMessage = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ErrorCode);
StringUtil.Serialize(ErrorMessage,bw);

        }
    }
}
