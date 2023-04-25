using BlogSite.Common.DTOs.Base;

namespace BlogSite.Common.DTOs.Transaction
{
    public class TCommentDto : BlogSiteMasterBaseDto
    {
        public string Comment { get; set; }
        public long ParentId { get; set; }
        public long Blog_ID { get; set; }
        public int User_ID { get; set; }

    }
}
