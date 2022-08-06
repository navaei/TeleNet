using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
    [TLObject(-1715350371)]
    public class TLJsonObject : TLAbsJSONValue
    {
        public override int Constructor
        {
            get
            {
                return -1715350371;
            }
        }

        public TLVector<TLJsonObjectValue> Value { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = ObjectUtils.DeserializeVector<TLJsonObjectValue>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Value, bw);

        }
    }
}
