using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Base
{
    public abstract class BaseDto<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
