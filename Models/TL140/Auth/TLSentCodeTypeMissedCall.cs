using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Auth
{
	[TLObject(-2113903484)]
    public class TLSentCodeTypeMissedCall : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2113903484;
            }
        }

             public string Prefix {get;set;}
     public int Length {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Prefix = StringUtil.Deserialize(br);
Length = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Prefix,bw);
bw.Write(Length);

        }
    }
}
