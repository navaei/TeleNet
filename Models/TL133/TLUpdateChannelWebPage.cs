using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(791390623)]
    public class TLUpdateChannelWebPage : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 791390623;
            }
        }

             public long ChannelId {get;set;}
     public TLAbsWebPage Webpage {get;set;}
     public int Pts {get;set;}
     public int PtsCount {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt64();
Webpage = (TLAbsWebPage)ObjectUtils.DeserializeObject(br);
Pts = br.ReadInt32();
PtsCount = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);
ObjectUtils.SerializeObject(Webpage,bw);
bw.Write(Pts);
bw.Write(PtsCount);

        }
    }
}
