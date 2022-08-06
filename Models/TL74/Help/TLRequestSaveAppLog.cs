using System.IO;

namespace TeleNet.Models.TL.Help
{
    [TLObject(1862465352)]
    public class TLRequestSaveAppLog : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1862465352;
            }
        }

        public TLVector<TLInputAppEvent> Events { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Events = (TLVector<TLInputAppEvent>)ObjectUtils.DeserializeVector<TLInputAppEvent>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Events, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
