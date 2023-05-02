using BlogSite.Common.DTOs.Base;

namespace BlogSite.Common.DTOs.Transaction
{
    public class TBlogDto : BlogSiteMasterBaseDto
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int ViewNumber { get; set; }
        public byte[] CoverImg { get; set; }
        public byte[] HeaderImg { get; set; }
        public byte[] ContentImg { get; set; }
        public int Category_ID { get; set; }
        public int User_ID { get; set; }
    }
}
