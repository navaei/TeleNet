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
    [TLObject(2137482273)]
    public class TLThemes : TLAbsThemes
    {
        public override int Constructor
        {
            get
            {
                return 2137482273;
            }
        }

        public int Hash { get; set; }
        public TLVector<TLTheme> Themes { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
            Themes = (TLVector<TLTheme>)ObjectUtils.DeserializeVector<TLTheme>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Themes, bw);

        }
    }
}
