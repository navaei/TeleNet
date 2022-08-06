using System.IO;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Help;

namespace TeleNet.Models.TL85.Help
{
    [TLObject(2013922064)]
    public class TLTermsOfService : TLAbsTermsOfService
    {
        public override int Constructor
        {
            get
            {
                return 2013922064;
            }
        }

        public int Flags { get; set; }
        public bool Popup { get; set; }
        public TLDataJSON Id { get; set; }
        public string Text { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }
        public int? MinAgeConfirm { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Popup ? (Flags | 1) : (Flags & ~1);
            Flags = MinAgeConfirm != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Popup = (Flags & 1) != 0;
            Id = (TLDataJSON)ObjectUtils.DeserializeObject(br);
            Text = StringUtil.Deserialize(br);
            Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            if ((Flags & 2) != 0)
                MinAgeConfirm = br.ReadInt32();
            else
                MinAgeConfirm = null;
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Id, bw);
            StringUtil.Serialize(Text, bw);
            ObjectUtils.SerializeObject(Entities, bw);
            if ((Flags & 2) != 0)
                bw.Write(MinAgeConfirm.Value);

        }
    }
}
