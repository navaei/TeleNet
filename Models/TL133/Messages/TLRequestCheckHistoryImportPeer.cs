using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(1573261059)]
    public class TLRequestCheckHistoryImportPeer : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1573261059;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
public Messages.TLCheckedHistoryImportPeer Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLCheckedHistoryImportPeer)ObjectUtils.DeserializeObject(br);

		}
    }
}
