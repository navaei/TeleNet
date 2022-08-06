using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Account;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(-1707242387)]
    public class TLThemes : TLAbsThemes
    {
        public override int Constructor
        {
            get
            {
                return -1707242387;
            }
        }

        public long Hash { get; set; }
        public TLVector<TLAbsTheme> Themes { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Themes = ObjectUtils.DeserializeVector<TLAbsTheme>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Themes, bw);

        }
    }
}
