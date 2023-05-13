using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Master;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Entities.Transaction
{
    public class TBlog : BlogSiteMasterBaseEntity
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public int ViewNumber { get; set; }

        public byte[] CoverImg { get; set; }
        public byte[] HeaderImg { get; set; }
        public byte[] ContentImg { get; set; }

        public int Category_ID { get; set; }
        public MCategory Category { get; set; }
        public bool IsApprove { get; set; }

        public int User_ID { get; set; }
        public User User { get; set; }

        public ICollection<TComment> Comments { get; set; }
        public ICollection<TMovement> Movements { get; set; }
    }
}
