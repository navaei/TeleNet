using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(1989032621)]
    public class TLAvailableReactions : TLAbsAvailableReactions
    {
        public override int Constructor
        {
            get
            {
                return 1989032621;
            }
        }

             public int Hash {get;set;}
     public TLVector<TLAvailableReaction> Reactions {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
Reactions = (TLVector<TLAvailableReaction>)ObjectUtils.DeserializeVector<TLAvailableReaction>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(Reactions,bw);

        }
    }
}
