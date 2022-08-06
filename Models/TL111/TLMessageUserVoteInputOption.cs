using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(909603888)]
    public class TLMessageUserVoteInputOption : TLAbsMessageUserVote
    {
        public override int Constructor
        {
            get
            {
                return 909603888;
            }
        }

             public int UserId {get;set;}
     public int Date {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(Date);

        }
    }
}
