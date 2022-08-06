using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1436924774)]
    public class TLRequestReceivedQueue : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1436924774;
            }
        }

        public int MaxQts { get; set; }
        public TLVector<long> Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            MaxQts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MaxQts);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }
    }
}
