using BlogSite.Core.DTOs.Base;
using BlogSite.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TBlogDto : BlogSiteMasterBaseDto
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int ViewNumber { get; set; }
        public int Category_ID { get; set; }
    }
}
