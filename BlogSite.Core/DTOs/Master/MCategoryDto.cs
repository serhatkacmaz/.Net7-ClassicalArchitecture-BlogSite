using BlogSite.Core.DTOs.Base;

namespace BlogSite.Core.DTOs.Master
{
    public class MCategoryDto : BlogSiteMasterBaseDto
    {
        public int ReferenceId { get; set; }
        public string Description { get; set; }
    }
}
