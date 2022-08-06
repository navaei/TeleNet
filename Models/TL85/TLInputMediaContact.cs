using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(-122978821)]
    public class TLInputMediaContact : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -122978821;
            }
        }

             public string PhoneNumber {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public string Vcard {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Vcard = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber,bw);
StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);
StringUtil.Serialize(Vcard,bw);

        }
    }
}
