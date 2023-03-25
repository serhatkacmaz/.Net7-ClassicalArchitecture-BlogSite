using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Transaction
{
    public class TImage : BlogSiteMasterBaseEntity<long>
    {
        public bool CoverArt { get; set; }

        public long Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
