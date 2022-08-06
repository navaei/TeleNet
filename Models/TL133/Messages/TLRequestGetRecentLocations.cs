using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(1881817312)]
    public class TLRequestGetRecentLocations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1881817312;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int Limit { get; set; }
        public long Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Limit = br.ReadInt32();
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(Limit);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
