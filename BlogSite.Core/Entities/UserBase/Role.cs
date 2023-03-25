using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.UserBase
{
    public class Role : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
