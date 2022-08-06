using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96.Account
{
    [TLObject(1995661875)]
    public class TLRequestSaveAutoDownloadSettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1995661875;
            }
        }

        public int Flags { get; set; }
        public bool Low { get; set; }
        public bool High { get; set; }
        public TL96.TLAutoDownloadSettings Settings { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Low ? (Flags | 1) : (Flags & ~1);
            Flags = High ? (Flags | 2) : (Flags & ~2);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Low = (Flags & 1) != 0;
            High = (Flags & 2) != 0;
            Settings = (TL96.TLAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Settings, bw);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
