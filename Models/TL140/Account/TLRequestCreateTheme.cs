using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
    [TLObject(1697530880)]
    public class TLRequestCreateTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1697530880;
            }
        }

        public int Flags { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public TLAbsInputDocument Document { get; set; }
        public TLVector<TL111.TLInputThemeSettings> Settings { get; set; }
        public TLTheme Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Document != null ? (Flags | 4) : (Flags & ~4);
            Flags = Settings != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Slug = StringUtil.Deserialize(br);
            Title = StringUtil.Deserialize(br);
            if ((Flags & 4) != 0)
                Document = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
            else
                Document = null;

            if ((Flags & 8) != 0)
                Settings = ObjectUtils.DeserializeVector<TL111.TLInputThemeSettings>(br);
            else
                Settings = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            StringUtil.Serialize(Slug, bw);
            StringUtil.Serialize(Title, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(Document, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(Settings, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLTheme)ObjectUtils.DeserializeObject(br);

        }
    }
}
