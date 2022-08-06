using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(1991897370)]
    public class TLMessageActionInviteToGroupCall : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 1991897370;
            }
        }

             public TLInputGroupCall Call {get;set;}
     public TLVector<int> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
Users = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
