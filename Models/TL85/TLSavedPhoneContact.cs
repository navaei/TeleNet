using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(289586518)]
    public class TLSavedPhoneContact : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 289586518;
            }
        }

             public string Phone {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public int Date {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Phone = StringUtil.Deserialize(br);
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Phone,bw);
StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);
bw.Write(Date);

        }
    }
}
