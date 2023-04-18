using BlogSite.Core.DTOs.Base;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TBlogDto : BlogSiteMasterBaseDto
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int ViewNumber { get; set; }
        public int Category_ID { get; set; }
        public bool IsActive { get; set; }
        public int User_ID { get; set; }
    }
}
