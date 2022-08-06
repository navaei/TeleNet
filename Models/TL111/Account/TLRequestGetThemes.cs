using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Account;

namespace TeleNet.Models.TL111.Account
{
    [TLObject(676939512)]
    public class TLRequestGetThemes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 676939512;
            }
        }

        public string Format { get; set; }
        public int Hash { get; set; }
        public TLAbsThemes Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Format = StringUtil.Deserialize(br);
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Format, bw);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsThemes)ObjectUtils.DeserializeObject(br);

        }
    }
}
