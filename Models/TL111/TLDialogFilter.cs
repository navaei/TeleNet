using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
    [TLObject(1949890536)]
    public class TLDialogFilter : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1949890536;
            }
        }

        public int Flags { get; set; }
        public bool Contacts { get; set; }
        public bool NonContacts { get; set; }
        public bool Groups { get; set; }
        public bool Broadcasts { get; set; }
        public bool Bots { get; set; }
        public bool ExcludeMuted { get; set; }
        public bool ExcludeRead { get; set; }
        public bool ExcludeArchived { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Emoticon { get; set; }
        public TLVector<TLAbsInputPeer> PinnedPeers { get; set; }
        public TLVector<TLAbsInputPeer> IncludePeers { get; set; }
        public TLVector<TLAbsInputPeer> ExcludePeers { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Contacts ? (Flags | 1) : (Flags & ~1);
            Flags = NonContacts ? (Flags | 2) : (Flags & ~2);
            Flags = Groups ? (Flags | 4) : (Flags & ~4);
            Flags = Broadcasts ? (Flags | 8) : (Flags & ~8);
            Flags = Bots ? (Flags | 16) : (Flags & ~16);
            Flags = ExcludeMuted ? (Flags | 2048) : (Flags & ~2048);
            Flags = ExcludeRead ? (Flags | 4096) : (Flags & ~4096);
            Flags = ExcludeArchived ? (Flags | 8192) : (Flags & ~8192);
            Flags = Emoticon != null ? (Flags | 33554432) : (Flags & ~33554432);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Contacts = (Flags & 1) != 0;
            NonContacts = (Flags & 2) != 0;
            Groups = (Flags & 4) != 0;
            Broadcasts = (Flags & 8) != 0;
            Bots = (Flags & 16) != 0;
            ExcludeMuted = (Flags & 2048) != 0;
            ExcludeRead = (Flags & 4096) != 0;
            ExcludeArchived = (Flags & 8192) != 0;
            Id = br.ReadInt32();
            Title = StringUtil.Deserialize(br);
            if ((Flags & 33554432) != 0)
                Emoticon = StringUtil.Deserialize(br);
            else
                Emoticon = null;

            PinnedPeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);
            IncludePeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);
            ExcludePeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            StringUtil.Serialize(Title, bw);
            if ((Flags & 33554432) != 0)
                StringUtil.Serialize(Emoticon, bw);
            ObjectUtils.SerializeObject(PinnedPeers, bw);
            ObjectUtils.SerializeObject(IncludePeers, bw);
            ObjectUtils.SerializeObject(ExcludePeers, bw);

        }
    }
}
