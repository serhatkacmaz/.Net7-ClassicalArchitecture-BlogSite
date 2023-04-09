using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Repositories
{
    public class MovementRepository : GenericRepository<TMovement>, IMovementRepository
    {
        public MovementRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
