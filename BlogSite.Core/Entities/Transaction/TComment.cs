using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Transaction
{
    public class TComment : BlogSiteMasterBaseEntity<long>
    {
        public string Comment { get; set; }        
        public long Parent_ID { get; set; }

        public long Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
