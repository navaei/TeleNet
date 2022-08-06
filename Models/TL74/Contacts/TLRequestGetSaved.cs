using System.IO;

namespace TeleNet.Models.TL.Contacts
{
	[TLObject(-2098076769)]
    public class TLRequestGetSaved : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2098076769;
            }
        }

                public TLVector<TLSavedPhoneContact> Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLSavedPhoneContact>)ObjectUtils.DeserializeVector<TLSavedPhoneContact>(br);

		}
    }
}
