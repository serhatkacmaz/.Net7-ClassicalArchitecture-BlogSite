using BlogSite.Core.Entities.Base;

namespace BlogSite.Core.Entities.Transaction
{
    public class TImage : BlogSiteMasterBaseEntity
    {
        public byte[] Image { get; set; }
        public bool CoverArt { get; set; }

        public int Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
