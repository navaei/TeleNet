using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL99.Messages
{
    [TLObject(899735650)]
    public class TLRequestGetEmojiKeywords : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 899735650;
            }
        }

        public string LangCode { get; set; }
        public TLEmojiKeywordsDifference Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(LangCode, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLEmojiKeywordsDifference)ObjectUtils.DeserializeObject(br);

        }
    }
}
