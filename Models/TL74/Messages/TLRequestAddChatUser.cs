using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-106911223)]
    public class TLRequestAddChatUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -106911223;
            }
        }

        public int ChatId { get; set; }
        public TLAbsInputUser UserId { get; set; }
        public int FwdLimit { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            FwdLimit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            ObjectUtils.SerializeObject(UserId, bw);
            bw.Write(FwdLimit);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
