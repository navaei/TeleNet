using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(1435512961)]
    public class TLGroupCall : TLAbsGroupCall
    {
        public override int Constructor
        {
            get
            {
                return 1435512961;
            }
        }

             public int Flags {get;set;}
     public bool JoinMuted {get;set;}
     public bool CanChangeJoinMuted {get;set;}
     public long Id {get;set;}
     public long AccessHash {get;set;}
     public int ParticipantsCount {get;set;}
     public TLDataJSON Params {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = JoinMuted ? (Flags | 2) : (Flags & ~2);
Flags = CanChangeJoinMuted ? (Flags | 4) : (Flags & ~4);
Flags = Params != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
JoinMuted = (Flags & 2) != 0;
CanChangeJoinMuted = (Flags & 4) != 0;
Id = br.ReadInt64();
AccessHash = br.ReadInt64();
ParticipantsCount = br.ReadInt32();
if ((Flags & 1) != 0)
Params = (TLDataJSON)ObjectUtils.DeserializeObject(br);
else
Params = null;

Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


bw.Write(Id);
bw.Write(AccessHash);
bw.Write(ParticipantsCount);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Params,bw);
bw.Write(Version);

        }
    }
}
