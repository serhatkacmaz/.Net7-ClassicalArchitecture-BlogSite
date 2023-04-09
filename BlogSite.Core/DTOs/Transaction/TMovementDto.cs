using BlogSite.Core.DTOs.Base;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TMovementDto : BaseDto
    {
        public EUserReaction EUserReaction { get; set; }
        public long Blog_ID { get; set; }
    }
}
