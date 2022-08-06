using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(88680979)]
    public class TLUpdateUserPhone : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 88680979;
            }
        }

             public long UserId {get;set;}
     public string Phone {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Phone = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
StringUtil.Serialize(Phone,bw);

        }
    }
}
