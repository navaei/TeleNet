using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(460632885)]
    public class TLBotInfo : TLAbsBotInfo
    {
        public override int Constructor
        {
            get
            {
                return 460632885;
            }
        }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            Description = StringUtil.Deserialize(br);
            Commands = (TLVector<TLBotCommand>)ObjectUtils.DeserializeVector<TLBotCommand>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            StringUtil.Serialize(Description, bw);
            ObjectUtils.SerializeObject(Commands, bw);

        }
    }
}
