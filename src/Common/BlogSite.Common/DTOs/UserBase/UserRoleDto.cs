using BlogSite.Common.DTOs.Base;

namespace BlogSite.Common.DTOs.UserBase
{
    public class UserRoleDto : BaseDto
    {
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
    }
}
