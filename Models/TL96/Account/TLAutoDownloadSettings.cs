using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96.Account
{
    [TLObject(1674235686)]
    public class TLAutoDownloadSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1674235686;
            }
        }

        public  TeleNet.Models.TL96.TLAutoDownloadSettings Low { get; set; }
        public  TeleNet.Models.TL96.TLAutoDownloadSettings Medium { get; set; }
        public  TeleNet.Models.TL96.TLAutoDownloadSettings High { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Low = ( TeleNet.Models.TL96.TLAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
            Medium = ( TeleNet.Models.TL96.TLAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
            High = ( TeleNet.Models.TL96.TLAutoDownloadSettings)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Low, bw);
            ObjectUtils.SerializeObject(Medium, bw);
            ObjectUtils.SerializeObject(High, bw);

        }
    }
}
