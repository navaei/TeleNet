using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1882335561)]
    public class TLMessageMediaContact : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1882335561;
            }
        }

             public string PhoneNumber {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public string Vcard {get;set;}
     public long UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Vcard = StringUtil.Deserialize(br);
UserId = br.ReadInt64();

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
