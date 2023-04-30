using BlogSite.Common.DTOs.Base;
using BlogSite.Common.Enums;

namespace BlogSite.Common.DTOs.Transaction
{
    public class TMovementDto : BaseDto
    {
        public EUserReaction EUserReaction { get; set; }
        public long Blog_ID { get; set; }
        public int User_ID { get; set; }
    }
}
