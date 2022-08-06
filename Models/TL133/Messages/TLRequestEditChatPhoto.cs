using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(903730804)]
    public class TLRequestEditChatPhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 903730804;
            }
        }

                public long ChatId {get;set;}
        public TLAbsInputChatPhoto Photo {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
Photo = (TLAbsInputChatPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(Photo,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
