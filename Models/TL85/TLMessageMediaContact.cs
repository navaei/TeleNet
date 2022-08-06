using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(-873313984)]
    public class TLMessageMediaContact : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -873313984;
            }
        }

             public string PhoneNumber {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public string Vcard {get;set;}
     public int UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Vcard = StringUtil.Deserialize(br);
UserId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber,bw);
StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);
StringUtil.Serialize(Vcard,bw);
bw.Write(UserId);

        }
    }
}
