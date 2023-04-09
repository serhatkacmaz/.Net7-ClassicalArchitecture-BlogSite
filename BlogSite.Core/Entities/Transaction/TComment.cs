using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Transaction
{
    public class TComment : BlogSiteMasterBaseEntity
    {
        public string Comment { get; set; }        
        public int ParentID { get; set; }

        public int Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
