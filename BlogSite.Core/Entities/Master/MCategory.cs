using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Entities.Master
{
    public class MCategory : BlogSiteMasterBaseEntity
    {
        public int ReferenceId { get; set; }
        public ICollection<TBlog> Blogs { get; set; }
    }
}
