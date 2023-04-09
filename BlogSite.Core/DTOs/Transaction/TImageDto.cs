using BlogSite.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TImageDto : BlogSiteMasterBaseDto
    {
        public byte[] Image { get; set; }
        public bool CoverArt { get; set; }
        public long Blog_ID { get; set; }
    }
}
