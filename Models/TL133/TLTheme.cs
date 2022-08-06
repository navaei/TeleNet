using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Account;

namespace TeleNet.Models.TL133
{
    [TLObject(-402474788)]
    public class TLTheme : TLAbsTheme
    {
        public override int Constructor
        {
            get
            {
                return -402474788;
            }
        }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Creator ? (Flags | 1) : (Flags & ~1);
            Flags = Default ? (Flags | 2) : (Flags & ~2);
            Flags = ForChat ? (Flags | 32) : (Flags & ~32);
            Flags = Document != null ? (Flags | 4) : (Flags & ~4);
            Flags = Settings != null ? (Flags | 8) : (Flags & ~8);
            Flags = InstallsCount != null ? (Flags | 16) : (Flags & ~16);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Creator = (Flags & 1) != 0;
            Default = (Flags & 2) != 0;
            ForChat = (Flags & 32) != 0;
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Slug = StringUtil.Deserialize(br);
            Title = StringUtil.Deserialize(br);
            if ((Flags & 4) != 0)
                Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                Document = null;

            if ((Flags & 8) != 0)
                Settings = (TLAbsThemeSettings)ObjectUtils.DeserializeObject(br);
            else
                Settings = null;

            if ((Flags & 16) != 0)
                InstallsCount = br.ReadInt32();
            else
                InstallsCount = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);



            bw.Write(Id);
            bw.Write(AccessHash);
            StringUtil.Serialize(Slug, bw);
            StringUtil.Serialize(Title, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(Document, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(Settings, bw);
            if ((Flags & 16) != 0)
                bw.Write(InstallsCount.Value);

        }
    }
}
