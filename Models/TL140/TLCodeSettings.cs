using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1973130814)]
    public class TLCodeSettings : TL96.TLAbsCodeSettings
    {
        public override int Constructor
        {
            get
            {
                return -1973130814;
            }
        }

        public int Flags { get; set; }
        public bool AllowFlashcall { get; set; }
        public bool CurrentNumber { get; set; }
        public bool AllowAppHash { get; set; }
        public bool AllowMissedCall { get; set; }
        public TLVector<byte[]> LogoutTokens { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = AllowFlashcall ? (Flags | 1) : (Flags & ~1);
            Flags = CurrentNumber ? (Flags | 2) : (Flags & ~2);
            Flags = AllowAppHash ? (Flags | 16) : (Flags & ~16);
            Flags = AllowMissedCall ? (Flags | 32) : (Flags & ~32);
            Flags = LogoutTokens != null ? (Flags | 64) : (Flags & ~64);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            AllowFlashcall = (Flags & 1) != 0;
            CurrentNumber = (Flags & 2) != 0;
            AllowAppHash = (Flags & 16) != 0;
            AllowMissedCall = (Flags & 32) != 0;
            if ((Flags & 64) != 0)
                LogoutTokens = (TLVector<byte[]>)ObjectUtils.DeserializeVector<byte[]>(br);
            else
                LogoutTokens = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);




            if ((Flags & 64) != 0)
                ObjectUtils.SerializeObject(LogoutTokens, bw);

        }
    }
}
