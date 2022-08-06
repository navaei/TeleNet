using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-603831608)]
    public class TLRequestSendWebViewData : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -603831608;
            }
        }

                public TLAbsInputUser Bot {get;set;}
        public long RandomId {get;set;}
        public string ButtonText {get;set;}
        public string Data {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
RandomId = br.ReadInt64();
ButtonText = StringUtil.Deserialize(br);
Data = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Bot,bw);
bw.Write(RandomId);
StringUtil.Serialize(ButtonText,bw);
StringUtil.Serialize(Data,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
