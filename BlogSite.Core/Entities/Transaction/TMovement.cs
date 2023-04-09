using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Entities.Transaction
{
    public enum EUserReaction : byte
    {
        None = 0,
        Like = 1,
        DisLike = 2,
        Favorite = 3
    }

    public class TMovement : BaseEntity
    {
        public EUserReaction EUserReaction { get; set; }

        public int Blog_ID { get; set; }
        public TBlog Blog { get; set; }
    }
}
