using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Help
{
    [TLObject(1783556146)]
    public class TLDeepLinkInfo : TLAbsDeepLinkInfo
    {
        public override int Constructor
        {
            get
            {
                return 1783556146;
            }
        }

        public int Flags { get; set; }
        public bool UpdateApp { get; set; }
        public string Message { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = UpdateApp ? (Flags | 1) : (Flags & ~1);
            Flags = Entities != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            UpdateApp = (Flags & 1) != 0;
            Message = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Message, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Entities, bw);

        }
    }
}
