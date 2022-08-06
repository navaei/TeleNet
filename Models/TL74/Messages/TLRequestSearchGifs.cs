using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1080395925)]
    public class TLRequestSearchGifs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1080395925;
            }
        }

        public string Q { get; set; }
        public int Offset { get; set; }
        public Messages.TLFoundGifs Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Q = StringUtil.Deserialize(br);
            Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Q, bw);
            bw.Write(Offset);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLFoundGifs)ObjectUtils.DeserializeObject(br);

        }
    }
}
