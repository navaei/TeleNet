using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Help
{
    [TLObject(-860107216)]
    public class TLAppUpdate : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -860107216;
            }
        }

        public int Flags { get; set; }
        public bool CanNotSkip { get; set; }
        public int Id { get; set; }
        public string Version { get; set; }
        public string Text { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }
        public TLAbsDocument Document { get; set; }
        public string Url { get; set; }
        public TLAbsDocument Sticker { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CanNotSkip ? (Flags | 1) : (Flags & ~1);
            Flags = Document != null ? (Flags | 2) : (Flags & ~2);
            Flags = Url != null ? (Flags | 4) : (Flags & ~4);
            Flags = Sticker != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            CanNotSkip = (Flags & 1) != 0;
            Id = br.ReadInt32();
            Version = StringUtil.Deserialize(br);
            Text = StringUtil.Deserialize(br);
            Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            if ((Flags & 2) != 0)
                Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                Document = null;

            if ((Flags & 4) != 0)
                Url = StringUtil.Deserialize(br);
            else
                Url = null;

            if ((Flags & 8) != 0)
                Sticker = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                Sticker = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            StringUtil.Serialize(Version, bw);
            StringUtil.Serialize(Text, bw);
            ObjectUtils.SerializeObject(Entities, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Document, bw);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(Url, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(Sticker, bw);

        }
    }
}
