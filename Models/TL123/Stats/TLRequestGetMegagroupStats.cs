using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Stats
{
	[TLObject(-589330937)]
    public class TLRequestGetMegagroupStats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -589330937;
            }
        }

                public int Flags {get;set;}
        public bool Dark {get;set;}
        public TLAbsInputChannel Channel {get;set;}
public Stats.TLMegagroupStats Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Dark ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Dark = (Flags & 1) != 0;
Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Channel,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Stats.TLMegagroupStats)ObjectUtils.DeserializeObject(br);

		}
    }
}
