using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-1816172929)]
    public class TLAttachMenuBotsBot : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1816172929;
            }
        }

             public TLAttachMenuBot Bot {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Bot = (TLAttachMenuBot)ObjectUtils.DeserializeObject(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Bot,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
