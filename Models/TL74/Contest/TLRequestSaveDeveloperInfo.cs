using System.IO;

namespace TeleNet.Models.TL.Contest
{
	[TLObject(-1705021803)]
    public class TLRequestSaveDeveloperInfo : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1705021803;
            }
        }

                public int VkId {get;set;}
        public string Name {get;set;}
        public string PhoneNumber {get;set;}
        public int Age {get;set;}
        public string City {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            VkId = br.ReadInt32();
Name = StringUtil.Deserialize(br);
PhoneNumber = StringUtil.Deserialize(br);
Age = br.ReadInt32();
City = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(VkId);
StringUtil.Serialize(Name,bw);
StringUtil.Serialize(PhoneNumber,bw);
bw.Write(Age);
StringUtil.Serialize(City,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
