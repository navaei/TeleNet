using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-648257196)]
    public class TLMessageActionSecureValuesSent : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -648257196;
            }
        }

             public TLVector<TLAbsSecureValueType> Types {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Types = (TLVector<TLAbsSecureValueType>)ObjectUtils.DeserializeVector<TLAbsSecureValueType>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Types,bw);

        }
    }
}
