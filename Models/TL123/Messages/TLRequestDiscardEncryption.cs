using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-208425312)]
    public class TLRequestDiscardEncryption : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -208425312;
            }
        }

        public int Flags { get; set; }
        public bool DeleteHistory { get; set; }
        public int ChatId { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = DeleteHistory ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            DeleteHistory = (Flags & 1) != 0;
            ChatId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(ChatId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
