using BlogSite.Core.Entities.Base;

namespace BlogSite.Core.Entities.UserBase
{
    public class Role : BlogSiteMasterBaseEntity
    {
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
