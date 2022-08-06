using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1609668650)]
    public class TLTheme : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1609668650;
            }
        }

        public int Flags { get; set; }
        public bool Creator { get; set; }
        public bool Default { get; set; }
        public bool ForChat { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public TLAbsDocument Document { get; set; }
        public TLVector<TL111.TLThemeSettings> Settings { get; set; }
        public string Emoticon { get; set; }
        public int? InstallsCount { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Creator ? (Flags | 1) : (Flags & ~1);
            Flags = Default ? (Flags | 2) : (Flags & ~2);
            Flags = ForChat ? (Flags | 32) : (Flags & ~32);
            Flags = Document != null ? (Flags | 4) : (Flags & ~4);
            Flags = Settings != null ? (Flags | 8) : (Flags & ~8);
            Flags = Emoticon != null ? (Flags | 64) : (Flags & ~64);
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
                Settings = ObjectUtils.DeserializeVector<TL111.TLThemeSettings>(br);
            else
                Settings = null;

            if ((Flags & 64) != 0)
                Emoticon = StringUtil.Deserialize(br);
            else
                Emoticon = null;

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
            if ((Flags & 64) != 0)
                StringUtil.Serialize(Emoticon, bw);
            if ((Flags & 16) != 0)
                bw.Write(InstallsCount.Value);

        }
    }
}
