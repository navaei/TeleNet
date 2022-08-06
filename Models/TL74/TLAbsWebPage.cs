namespace TeleNet.Models.TL
{
    public abstract class TLAbsWebPage : TLObject
    {
        public int Flags { get; set; }
        public long Id { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public int Hash { get; set; }
        public string Type { get; set; }
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TLAbsPhoto Photo { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedType { get; set; }
        public int? EmbedWidth { get; set; }
        public int? EmbedHeight { get; set; }
        public int? Duration { get; set; }
        public string Author { get; set; }
        public TLAbsDocument Document { get; set; }
        public TLAbsPage CachedPage { get; set; }

    }
}
