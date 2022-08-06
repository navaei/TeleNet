using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-380694650)]
    public class TLInputPrivacyValueDisallowChatParticipants : TLAbsInputPrivacyRule
    {
        public override int Constructor
        {
            get
            {
                return -380694650;
            }
        }

             public TLVector<long> Chats {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Chats = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Chats,bw);

        }
    }
}
