using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Master
{
    public class MCategory : BlogSiteMasterBaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ICollection<TBlog> Blogs { get; set; }
    }
}
