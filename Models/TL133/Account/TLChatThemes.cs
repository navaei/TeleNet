using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(-28524867)]
    public class TLChatThemes : TLAbsChatThemes
    {
        public override int Constructor
        {
            get
            {
                return -28524867;
            }
        }

        public int Hash { get; set; }
        public TLVector<TLChatTheme> Themes { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
            Themes = (TLVector<TLChatTheme>)ObjectUtils.DeserializeVector<TLChatTheme>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Themes, bw);

        }
    }
}
