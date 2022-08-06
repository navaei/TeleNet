using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(651135312)]
    public class TLRequestGetDhConfig : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 651135312;
            }
        }

        public int Version { get; set; }
        public int RandomLength { get; set; }
        public TLAbsDhConfig Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Version = br.ReadInt32();
            RandomLength = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Version);
            bw.Write(RandomLength);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsDhConfig)ObjectUtils.DeserializeObject(br);

        }
    }
}
