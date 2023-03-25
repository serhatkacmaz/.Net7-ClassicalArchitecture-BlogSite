using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.UserBase
{
    public class UserRole : BaseEntity<int>
    {
        public int Role_ID { get; set; }
        public Role Role { get; set; }

        public int User_ID { get; set; }
        public User User { get; set; }
    }
}
