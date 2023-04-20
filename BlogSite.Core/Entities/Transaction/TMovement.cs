using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.UserBase;

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

        public int User_ID { get; set; }
        public User User { get; set; }
    }
}
