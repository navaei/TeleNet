using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-900957736)]
    public class TLRequestEditChatPhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -900957736;
            }
        }

        public int ChatId { get; set; }
        public TLAbsInputChatPhoto Photo { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
            Photo = (TLAbsInputChatPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            ObjectUtils.SerializeObject(Photo, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
