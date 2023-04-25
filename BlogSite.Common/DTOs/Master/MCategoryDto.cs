using BlogSite.Common.DTOs.Base;

namespace BlogSite.Common.DTOs.Master
{
    public class MCategoryDto : BlogSiteMasterBaseDto
    {
        public int ReferenceId { get; set; }
        public string Description { get; set; }
    }
}
