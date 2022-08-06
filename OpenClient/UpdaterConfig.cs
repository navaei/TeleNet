namespace TeleNet.OpenClient
{
    class UpdaterConfig
    {
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }

        public string LocalProxy { get; set; }

        public string ApiHash { get; set; }
        public int ApiId { get; set; }
        public string SessionName { get; set; }
    }
}