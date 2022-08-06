using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-9666487)]
    public class TLNotificationSoundRingtone : TLAbsNotificationSound
    {
        public override int Constructor
        {
            get
            {
                return -9666487;
            }
        }

             public long Id {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
