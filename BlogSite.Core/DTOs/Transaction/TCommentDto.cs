using BlogSite.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TCommentDto : BlogSiteMasterBaseDto
    {
        public string Comment { get; set; }
        public long Parent_ID { get; set; }
        public long Blog_ID { get; set; }
    }
}
