using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(274961865)]
    public class TLUpdateMessagePollVote : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 274961865;
            }
        }

             public long PollId {get;set;}
     public long UserId {get;set;}
     public TLVector<byte[]> Options {get;set;}
     public int Qts {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PollId = br.ReadInt64();
UserId = br.ReadInt64();
Options = (TLVector<byte[]>)ObjectUtils.DeserializeVector<byte[]>(br);
Qts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(PollId);
bw.Write(UserId);
ObjectUtils.SerializeObject(Options,bw);
bw.Write(Qts);

        }
    }
}
