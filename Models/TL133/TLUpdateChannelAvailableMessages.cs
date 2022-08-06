using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1304443240)]
    public class TLUpdateChannelAvailableMessages : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1304443240;
            }
        }

             public long ChannelId {get;set;}
     public int AvailableMinId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt64();
AvailableMinId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);
bw.Write(AvailableMinId);

        }
    }
}
