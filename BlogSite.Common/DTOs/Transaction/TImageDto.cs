using BlogSite.Common.DTOs.Base;

namespace BlogSite.Common.DTOs.Transaction
{
    public class TImageDto : BlogSiteMasterBaseDto
    {
        public byte[] Image { get; set; }
        public bool CoverArt { get; set; }
        public long Blog_ID { get; set; }
    }
}
