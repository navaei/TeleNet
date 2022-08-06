using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-230206493)]
    public class TLRequestAddChatUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -230206493;
            }
        }

                public long ChatId {get;set;}
        public TLAbsInputUser UserId {get;set;}
        public int FwdLimit {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
FwdLimit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(UserId,bw);
bw.Write(FwdLimit);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
