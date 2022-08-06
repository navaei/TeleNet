using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(-326762118)]
    public class TLRequestRegisterDevice : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -326762118;
            }
        }

        public int Flags { get; set; }
        public bool NoMuted { get; set; }
        public int TokenType { get; set; }
        public string Token { get; set; }
        public bool AppSandbox { get; set; }
        public byte[] Secret { get; set; }
        public TLVector<long> OtherUids { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = NoMuted ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            NoMuted = (Flags & 1) != 0;
            TokenType = br.ReadInt32();
            Token = StringUtil.Deserialize(br);
            AppSandbox = BoolUtil.Deserialize(br);
            Secret = BytesUtil.Deserialize(br);
            OtherUids = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(TokenType);
            StringUtil.Serialize(Token, bw);
            BoolUtil.Serialize(AppSandbox, bw);
            BytesUtil.Serialize(Secret, bw);
            ObjectUtils.SerializeObject(OtherUids, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
