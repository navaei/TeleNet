using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Phone
{
	[TLObject(-790330702)]
    public class TLGroupCallStreamChannels : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -790330702;
            }
        }

             public TLVector<TLGroupCallStreamChannel> Channels {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channels = (TLVector<TLGroupCallStreamChannel>)ObjectUtils.DeserializeVector<TLGroupCallStreamChannel>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channels,bw);

        }
    }
}
