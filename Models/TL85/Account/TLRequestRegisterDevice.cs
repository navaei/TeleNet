using System.IO;

namespace  TeleNet.Models.TL85.Account
{
    [TLObject(1555998096)]
    public class TLRequestRegisterDevice : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1555998096;
            }
        }

        public int TokenType { get; set; }
        public string Token { get; set; }
        public bool AppSandbox { get; set; }
        public byte[] Secret { get; set; }
        public TLVector<int> OtherUids { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            TokenType = br.ReadInt32();
            Token = StringUtil.Deserialize(br);
            AppSandbox = BoolUtil.Deserialize(br);
            Secret = BytesUtil.Deserialize(br);
            OtherUids = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
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
