using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Users
{
	[TLObject(-1240508136)]
    public class TLRequestGetFullUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1240508136;
            }
        }

                public TLAbsInputUser Id {get;set;}
public Users.TLUserFull Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Users.TLUserFull)ObjectUtils.DeserializeObject(br);

		}
    }
}
