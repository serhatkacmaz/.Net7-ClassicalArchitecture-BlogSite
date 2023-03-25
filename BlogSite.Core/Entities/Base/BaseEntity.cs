using BlogSite.Core.Entities.UserBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Base
{
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public long? User_ID { get; set; }
        public User User { get; set; }
    }
}
