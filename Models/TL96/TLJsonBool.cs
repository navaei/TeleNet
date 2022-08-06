using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(-952869270)]
    public class TLJsonBool : TLAbsJSONValue
    {
        public override int Constructor
        {
            get
            {
                return -952869270;
            }
        }

             public bool Value {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Value = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(Value,bw);

        }
    }
}
