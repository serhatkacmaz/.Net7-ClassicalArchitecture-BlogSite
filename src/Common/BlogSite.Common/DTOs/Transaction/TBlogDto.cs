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
        public string UserName { get; set; }
        public byte[] UserImg { get; set; }
        public string UserAbout { get; set; }
        public string UserTitle { get; set; }
        public List<CommentModel> CommentModels { get; set; }
    }

    public class CommentModel
    {
        public byte[] UserImg { get; set; }
        public string UserFullName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
