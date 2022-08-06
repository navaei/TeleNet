using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Bots
{
    [TLObject(2021942497)]
    public class TLRequestSetBotBroadcastDefaultAdminRights : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2021942497;
            }
        }

        public TL96.TLChatAdminRights AdminRights { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            AdminRights = (TL96.TLChatAdminRights)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(AdminRights, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
