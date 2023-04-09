using BlogSite.Core.DTOs.Base;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TImageDto : BlogSiteMasterBaseDto
    {
        public byte[] Image { get; set; }
        public bool CoverArt { get; set; }
        public long Blog_ID { get; set; }
    }
}
