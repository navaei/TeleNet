using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Channels
{
	[TLObject(-1683319225)]
    public class TLRequestDeleteHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1683319225;
            }
        }

                public int Flags {get;set;}
        public bool ForEveryone {get;set;}
        public TLAbsInputChannel Channel {get;set;}
        public int MaxId {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = ForEveryone ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ForEveryone = (Flags & 1) != 0;
Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
MaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Channel,bw);
bw.Write(MaxId);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
