using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-1470377534)]
    public class TLRequestEditChatAdmin : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1470377534;
            }
        }

                public long ChatId {get;set;}
        public TLAbsInputUser UserId {get;set;}
        public bool IsAdmin {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
IsAdmin = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(UserId,bw);
BoolUtil.Serialize(IsAdmin,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
