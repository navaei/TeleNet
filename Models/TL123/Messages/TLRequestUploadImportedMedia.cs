using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(713433234)]
    public class TLRequestUploadImportedMedia : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 713433234;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public long ImportId { get; set; }
        public string FileName { get; set; }
        public TLAbsInputMedia Media { get; set; }
        public TLAbsMessageMedia Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            ImportId = br.ReadInt64();
            FileName = StringUtil.Deserialize(br);
            Media = (TLAbsInputMedia)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(ImportId);
            StringUtil.Serialize(FileName, bw);
            ObjectUtils.SerializeObject(Media, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);

        }
    }
}
