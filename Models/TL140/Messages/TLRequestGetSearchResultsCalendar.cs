using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(1240514025)]
    public class TLRequestGetSearchResultsCalendar : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1240514025;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public TLAbsMessagesFilter Filter {get;set;}
        public int OffsetId {get;set;}
        public int OffsetDate {get;set;}
public Messages.TLSearchResultsCalendar Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
OffsetId = br.ReadInt32();
OffsetDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(Filter,bw);
bw.Write(OffsetId);
bw.Write(OffsetDate);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLSearchResultsCalendar)ObjectUtils.DeserializeObject(br);

		}
    }
}
