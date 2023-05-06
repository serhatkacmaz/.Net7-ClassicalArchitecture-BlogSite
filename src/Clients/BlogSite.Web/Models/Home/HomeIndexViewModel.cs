namespace BlogSite.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public byte[] BlogImg { get; set; }
        public string BlogTitle { get; set; }
        public byte[] UserImg { get; set; }
        public string UserFullName { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }
        public int CommentCount { get; set; }
    }
}
