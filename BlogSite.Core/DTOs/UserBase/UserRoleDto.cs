using BlogSite.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.UserBase
{
    public class UserRoleDto : BlogSiteMasterBaseDto
    {
        public int User_ID { get; set; }
        public int Role_ID { get; set; }
    }
}
