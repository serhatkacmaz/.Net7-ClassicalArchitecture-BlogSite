namespace BlogSite.Web.Models.UserDashboard
{
    public class BlogListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
