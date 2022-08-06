using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-232290676)]
    public class TLUpdateUserPhoto : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -232290676;
            }
        }

        public long UserId { get; set; }
        public int Date { get; set; }
        public TLAbsUserProfilePhoto Photo { get; set; }
        public bool Previous { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            Date = br.ReadInt32();
            Photo = (TLAbsUserProfilePhoto)ObjectUtils.DeserializeObject(br);
            Previous = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Photo, bw);
            BoolUtil.Serialize(Previous, bw);

        }
    }
}
