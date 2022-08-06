using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(1855292323)]
    public class TLRequestGetSearchResultsPositions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1855292323;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLAbsMessagesFilter Filter { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }
        public Messages.TLSearchResultsPositions Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Filter, bw);
            bw.Write(OffsetId);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLSearchResultsPositions)ObjectUtils.DeserializeObject(br);

        }
    }
}
