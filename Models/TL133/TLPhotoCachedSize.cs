using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(35527382)]
    public class TLPhotoCachedSize : TLAbsPhotoSize
    {
        public override int Constructor
        {
            get
            {
                return 35527382;
            }
        }

        public byte[] Bytes { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Type = StringUtil.Deserialize(br);
            W = br.ReadInt32();
            H = br.ReadInt32();
            Bytes = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Type, bw);
            bw.Write(W);
            bw.Write(H);
            BytesUtil.Serialize(Bytes, bw);

        }
    }
}
