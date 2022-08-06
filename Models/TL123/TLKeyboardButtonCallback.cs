using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(901503851)]
    public class TLKeyboardButtonCallback : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return 901503851;
            }
        }

        public int Flags { get; set; }
        public bool RequiresPassword { get; set; }
        public string Text { get; set; }
        public byte[] Data { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = RequiresPassword ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            RequiresPassword = (Flags & 1) != 0;
            Text = StringUtil.Deserialize(br);
            Data = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Text, bw);
            BytesUtil.Serialize(Data, bw);

        }
    }
}
