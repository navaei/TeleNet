using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-219423922)]
    public class TLUpdateGroupCallParticipants : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -219423922;
            }
        }

             public TLInputGroupCall Call {get;set;}
     public TLVector<TLGroupCallParticipant> Participants {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
Participants = (TLVector<TLGroupCallParticipant>)ObjectUtils.DeserializeVector<TLGroupCallParticipant>(br);
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call,bw);
ObjectUtils.SerializeObject(Participants,bw);
bw.Write(Version);

        }
    }
}
