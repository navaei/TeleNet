using System;
using System.Collections.Generic;
using System.Text;

namespace TeleNet.Models.TL
{
    public abstract class TLAbsStickerSet : TLObject
    {
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public int Flags { get; set; }
        public bool Archived { get; set; }
        public bool Official { get; set; }
        public bool Masks { get; set; }
        public int Count { get; set; }
        public int Hash { get; set; }
        public bool Installed { get; set; }
        public bool Animated { get; set; }
        public int? InstalledDate { get; set; }

    }
}
