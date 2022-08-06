using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Channels
{
    [TLObject(-751007486)]
    public class TLRequestEditAdmin : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -751007486;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLAbsInputUser UserId { get; set; }
        public TLAbsChatAdminRights AdminRights { get; set; }
        public string Rank { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
            Rank = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            ObjectUtils.SerializeObject(UserId, bw);
            ObjectUtils.SerializeObject(AdminRights, bw);
            StringUtil.Serialize(Rank, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
