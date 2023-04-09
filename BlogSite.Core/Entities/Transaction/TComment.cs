using BlogSite.Core.Entities.Base;

namespace BlogSite.Core.Entities.Transaction
{
    public class TComment : BlogSiteMasterBaseEntity
    {
        public string Comment { get; set; }
        public int ParentID { get; set; }

        public int Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
