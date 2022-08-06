using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Auth
{
    [TLObject(-1012759713)]
    public class TLLoggedOut : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1012759713;
            }
        }

        public int Flags { get; set; }
        public byte[] FutureAuthToken { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = FutureAuthToken != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                FutureAuthToken = BytesUtil.Deserialize(br);
            else
                FutureAuthToken = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                BytesUtil.Serialize(FutureAuthToken, bw);

        }
    }
}
