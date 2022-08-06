using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1119368275)]
    public class TLMessageActionChatCreate : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1119368275;
            }
        }

             public string Title {get;set;}
     public TLVector<long> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);
Users = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Title,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
