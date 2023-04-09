using BlogSite.Core.DTOs.Base;

namespace BlogSite.Core.DTOs.UserBase
{
    public class UserRoleDto : BlogSiteMasterBaseDto
    {
        public int User_ID { get; set; }
        public int Role_ID { get; set; }
    }
}
