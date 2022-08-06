using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(1790652275)]
    public class TLRequestRequestSimpleWebView : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1790652275;
            }
        }

        public int Flags { get; set; }
        public TLAbsInputUser Bot { get; set; }
        public string Url { get; set; }
        public TLDataJSON ThemeParams { get; set; }
        public TLAbsSimpleWebViewResult Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ThemeParams != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            Url = StringUtil.Deserialize(br);
            if ((Flags & 1) != 0)
                ThemeParams = (TLDataJSON)ObjectUtils.DeserializeObject(br);
            else
                ThemeParams = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Bot, bw);
            StringUtil.Serialize(Url, bw);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(ThemeParams, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsSimpleWebViewResult)ObjectUtils.DeserializeObject(br);

        }
    }
}
