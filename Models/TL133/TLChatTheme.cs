using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-318022605)]
    public class TLChatTheme : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -318022605;
            }
        }

        public string Emoticon { get; set; }
        public TeleNet.Models.TL.TLAbsTheme Theme { get; set; }
        public TeleNet.Models.TL.TLAbsTheme DarkTheme { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);
            Theme = ( TeleNet.Models.TL.TLAbsTheme)ObjectUtils.DeserializeObject(br);
            DarkTheme = ( TeleNet.Models.TL.TLAbsTheme)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Emoticon, bw);
            ObjectUtils.SerializeObject(Theme, bw);
            ObjectUtils.SerializeObject(DarkTheme, bw);

        }
    }
}
