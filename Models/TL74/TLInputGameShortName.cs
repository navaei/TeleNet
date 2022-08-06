using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1020139510)]
    public class TLInputGameShortName : TLAbsInputGame
    {
        public override int Constructor
        {
            get
            {
                return -1020139510;
            }
        }

        public TLAbsInputUser BotId { get; set; }
        public string ShortName { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            BotId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            ShortName = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(BotId, bw);
            StringUtil.Serialize(ShortName, bw);

        }
    }
}
