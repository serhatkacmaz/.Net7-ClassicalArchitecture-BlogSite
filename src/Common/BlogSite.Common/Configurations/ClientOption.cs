namespace BlogSite.Common.Configurations
{
    public class ClientOption
    {
        public string Id { get; set; }
        public string Secret { get; set; }

        public List<string> Audiences { get; set; }
    }
}
