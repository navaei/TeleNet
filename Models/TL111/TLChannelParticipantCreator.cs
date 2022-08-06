using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-2138237532)]
    public class TLChannelParticipantCreator : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return -2138237532;
            }
        }

             public int Flags {get;set;}
     public int UserId {get;set;}
     public string Rank {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Rank != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
UserId = br.ReadInt32();
if ((Flags & 1) != 0)
Rank = StringUtil.Deserialize(br);
else
Rank = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(UserId);
if ((Flags & 1) != 0)
StringUtil.Serialize(Rank,bw);

        }
    }
}
