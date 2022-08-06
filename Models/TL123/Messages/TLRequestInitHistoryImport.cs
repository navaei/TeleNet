using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(873008187)]
    public class TLRequestInitHistoryImport : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 873008187;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLAbsInputFile File { get; set; }
        public int MediaCount { get; set; }
        public Messages.TLHistoryImport Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
            MediaCount = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(File, bw);
            bw.Write(MediaCount);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLHistoryImport)ObjectUtils.DeserializeObject(br);

        }
    }
}
