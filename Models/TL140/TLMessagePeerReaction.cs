using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(1370914559)]
    public class TLMessagePeerReaction : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1370914559;
            }
        }

             public int Flags {get;set;}
     public bool Big {get;set;}
     public bool Unread {get;set;}
     public TLAbsPeer PeerId {get;set;}
     public string Reaction {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Big ? (Flags | 1) : (Flags & ~1);
Flags = Unread ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Big = (Flags & 1) != 0;
Unread = (Flags & 2) != 0;
PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Reaction = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


ObjectUtils.SerializeObject(PeerId,bw);
StringUtil.Serialize(Reaction,bw);

        }
    }
}
