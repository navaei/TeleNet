using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-2054649973)]
    public class TLUpdatePinnedChannelMessages : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -2054649973;
            }
        }

             public int Flags {get;set;}
     public bool Pinned {get;set;}
     public int ChannelId {get;set;}
     public TLVector<int> Messages {get;set;}
     public int Pts {get;set;}
     public int PtsCount {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Pinned ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Pinned = (Flags & 1) != 0;
ChannelId = br.ReadInt32();
Messages = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
Pts = br.ReadInt32();
PtsCount = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(ChannelId);
ObjectUtils.SerializeObject(Messages,bw);
bw.Write(Pts);
bw.Write(PtsCount);

        }
    }
}
