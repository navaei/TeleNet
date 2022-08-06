using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(1065280907)]
    public class TLMessageMediaDice : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return 1065280907;
            }
        }

        public int Value { get; set; }
        public string Emoticon { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = br.ReadInt32();
            Emoticon = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Value);
            StringUtil.Serialize(Emoticon, bw);

        }
    }
}
