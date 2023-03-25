using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Transaction
{
    public class TBlog : BlogSiteMasterBaseEntity<long>
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int ViewNumber { get; set; }
        public int LikesNumber { get; set; }
        public int DislikesNumber { get; set; }

        public int Category_ID { get; set; }
        public MCategory Category { get; set; }

        public ICollection<TImage> Images { get; set; }
        public ICollection<TComment> Comments { get; set; }
    }
}
