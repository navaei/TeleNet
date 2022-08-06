using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-2096391452)]
    public class TLNotificationSoundLocal : TLAbsNotificationSound
    {
        public override int Constructor
        {
            get
            {
                return -2096391452;
            }
        }

             public string Title {get;set;}
     public string Data {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);
Data = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Title,bw);
StringUtil.Serialize(Data,bw);

        }
    }
}
