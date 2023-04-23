using BlogSite.Core.DTOs.Base;

namespace BlogSite.Core.DTOs.UserBase
{
    public class UserRoleDto : BaseDto
    {
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
    }
}
