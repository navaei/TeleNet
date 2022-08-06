using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL99
{
    [TLObject(1197267925)]
    public class TLChatPhoto : TLAbsChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return 1197267925;
            }
        }

        public TLAbsFileLocation PhotoSmall { get; set; }
        public TLAbsFileLocation PhotoBig { get; set; }
        public int DcId { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhotoSmall = (TLAbsFileLocation)ObjectUtils.DeserializeObject(br);
            PhotoBig = (TLAbsFileLocation)ObjectUtils.DeserializeObject(br);
            DcId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PhotoSmall, bw);
            ObjectUtils.SerializeObject(PhotoBig, bw);
            bw.Write(DcId);

        }
    }
}
