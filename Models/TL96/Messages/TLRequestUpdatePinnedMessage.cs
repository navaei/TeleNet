using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96.Messages
{
    [TLObject(-760547348)]
    public class TLRequestUpdatePinnedMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -760547348;
            }
        }

        public int Flags { get; set; }
        public bool Silent { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public int Id { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Silent ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Silent = (Flags & 1) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Id = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(Id);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
