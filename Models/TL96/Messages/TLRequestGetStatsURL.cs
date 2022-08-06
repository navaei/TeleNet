using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96.Messages
{
	[TLObject(-2127811866)]
    public class TLRequestGetStatsURL : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2127811866;
            }
        }

                public int Flags {get;set;}
        public bool Dark {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public string Params {get;set;}
public TLStatsURL Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Dark ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Dark = (Flags & 1) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Params = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
StringUtil.Serialize(Params,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLStatsURL)ObjectUtils.DeserializeObject(br);

		}
    }
}
