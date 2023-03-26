using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Base
{
    public abstract class BlogSiteMasterBaseDto<T> : BaseDto<T>
    {
        public string Name { get; set; }
    }
}
