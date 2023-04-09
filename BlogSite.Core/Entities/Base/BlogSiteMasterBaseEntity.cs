using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Entities.Base
{
    public abstract class BlogSiteMasterBaseEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
