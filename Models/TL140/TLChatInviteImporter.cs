using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-1940201511)]
    public class TLChatInviteImporter : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1940201511;
            }
        }

             public int Flags {get;set;}
     public bool Requested {get;set;}
     public long UserId {get;set;}
     public int Date {get;set;}
     public string About {get;set;}
     public long? ApprovedBy {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Requested ? (Flags | 1) : (Flags & ~1);
Flags = About != null ? (Flags | 4) : (Flags & ~4);
Flags = ApprovedBy != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Requested = (Flags & 1) != 0;
UserId = br.ReadInt64();
Date = br.ReadInt32();
if ((Flags & 4) != 0)
About = StringUtil.Deserialize(br);
else
About = null;

if ((Flags & 2) != 0)
ApprovedBy = br.ReadInt64();
else
ApprovedBy = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(UserId);
bw.Write(Date);
if ((Flags & 4) != 0)
StringUtil.Serialize(About,bw);
if ((Flags & 2) != 0)
bw.Write(ApprovedBy.Value);

        }
    }
}
