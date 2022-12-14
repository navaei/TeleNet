using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL99
{
	[TLObject(1129042607)]
    public class TLChannelAdminLogEventActionChangePhoto : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1129042607;
            }
        }

             public TLAbsPhoto PrevPhoto {get;set;}
     public TLAbsPhoto NewPhoto {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PrevPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
NewPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(PrevPhoto,bw);
ObjectUtils.SerializeObject(NewPhoto,bw);

        }
    }
}
