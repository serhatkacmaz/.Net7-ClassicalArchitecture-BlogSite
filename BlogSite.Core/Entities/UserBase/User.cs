using BlogSite.Core.Entities.Base;

namespace BlogSite.Core.Entities.UserBase
{
    public class User : BlogSiteMasterBaseEntity
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
