using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-1575461717)]
    public class TLRequestDeleteChatUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1575461717;
            }
        }

                public int Flags {get;set;}
        public bool RevokeHistory {get;set;}
        public long ChatId {get;set;}
        public TLAbsInputUser UserId {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = RevokeHistory ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
RevokeHistory = (Flags & 1) != 0;
ChatId = br.ReadInt64();
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

bw.Write(ChatId);
ObjectUtils.SerializeObject(UserId,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
