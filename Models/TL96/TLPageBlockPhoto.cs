using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(391759200)]
    public class TLPageBlockPhoto : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 391759200;
            }
        }

             public int Flags {get;set;}
     public long PhotoId {get;set;}
     public TLPageCaption Caption {get;set;}
     public string Url {get;set;}
     public long? WebpageId {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Url != null ? (Flags | 1) : (Flags & ~1);
Flags = WebpageId != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
PhotoId = br.ReadInt64();
Caption = (TLPageCaption)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
Url = StringUtil.Deserialize(br);
else
Url = null;

if ((Flags & 1) != 0)
WebpageId = br.ReadInt64();
else
WebpageId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(PhotoId);
ObjectUtils.SerializeObject(Caption,bw);
if ((Flags & 1) != 0)
StringUtil.Serialize(Url,bw);
if ((Flags & 1) != 0)
bw.Write(WebpageId.Value);

        }
    }
}
