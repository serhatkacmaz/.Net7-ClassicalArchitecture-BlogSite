using BlogSite.Core.DTOs.Base;
using BlogSite.Core.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.DTOs.Transaction
{
    public class TMovementDto : BaseDto
    {
        public EUserReaction EUserReaction { get; set; }
        public long Blog_ID { get; set; }
    }
}
