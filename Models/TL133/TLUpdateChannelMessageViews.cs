using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-232346616)]
    public class TLUpdateChannelMessageViews : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -232346616;
            }
        }

             public long ChannelId {get;set;}
     public int Id {get;set;}
     public int Views {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt64();
Id = br.ReadInt32();
Views = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);
bw.Write(Id);
bw.Write(Views);

        }
    }
}
