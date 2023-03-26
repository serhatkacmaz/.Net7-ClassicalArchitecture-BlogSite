using BlogSite.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Master
{
    public class MCategoryDto : BlogSiteMasterBaseDto<int>
    {
        public int ReferenceId { get; set; }
    }
}
