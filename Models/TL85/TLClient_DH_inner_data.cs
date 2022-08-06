using System.IO;

namespace  TeleNet.Models.TL85
{
    [TLObject(1715713620)]
    public class TLClient_DH_inner_data : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1715713620;
            }
        }

        public long Nonce { get; set; }
        public long ServerNonce { get; set; }
        public long RetryId { get; set; }
        public string GB { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = LongUtil.Deserialize(br);
            ServerNonce = LongUtil.Deserialize(br);
            RetryId = br.ReadInt64();
            GB = StringUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce, bw);
            ObjectUtils.SerializeObject(ServerNonce, bw);
            bw.Write(RetryId);
            StringUtil.Serialize(GB, bw);

        }
    }
}
