using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(860303448)]
    public class TLInputMediaDocument : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 860303448;
            }
        }

             public int Flags {get;set;}
     public TLAbsInputDocument Id {get;set;}
     public int? TtlSeconds {get;set;}
     public string Query {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = TtlSeconds != null ? (Flags | 1) : (Flags & ~1);
Flags = Query != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Id = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
TtlSeconds = br.ReadInt32();
else
TtlSeconds = null;

if ((Flags & 2) != 0)
Query = StringUtil.Deserialize(br);
else
Query = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(Id,bw);
if ((Flags & 1) != 0)
bw.Write(TtlSeconds.Value);
if ((Flags & 2) != 0)
StringUtil.Serialize(Query,bw);

        }
    }
}
