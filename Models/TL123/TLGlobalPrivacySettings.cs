using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-1096616924)]
    public class TLGlobalPrivacySettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1096616924;
            }
        }

             public int Flags {get;set;}
     public bool? ArchiveAndMuteNewNoncontactPeers {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = ArchiveAndMuteNewNoncontactPeers != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
ArchiveAndMuteNewNoncontactPeers = BoolUtil.Deserialize(br);
else
ArchiveAndMuteNewNoncontactPeers = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
if ((Flags & 1) != 0)
BoolUtil.Serialize(ArchiveAndMuteNewNoncontactPeers.Value,bw);

        }
    }
}
