namespace BlogSite.Web.Models.UserDashboard
{
    public class UserTrackingViewModel
    {
        public int BlogCount { get; set; }
        public int ViewCount { get; set; }
        public int TotalLikeCount { get; set; }
        public int TotalDislikeCount { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
