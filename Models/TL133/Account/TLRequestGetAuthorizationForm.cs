using System.IO;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(-1456907910)]
    public class TLRequestGetAuthorizationForm : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1456907910;
            }
        }

        public long BotId { get; set; }
        public string Scope { get; set; }
        public string PublicKey { get; set; }
        public TL.Account.TLAuthorizationForm Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            BotId = br.ReadInt64();
            Scope = StringUtil.Deserialize(br);
            PublicKey = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(BotId);
            StringUtil.Serialize(Scope, bw);
            StringUtil.Serialize(PublicKey, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Account.TLAuthorizationForm)ObjectUtils.DeserializeObject(br);

        }
    }
}
