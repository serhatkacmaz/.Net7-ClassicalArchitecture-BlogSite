using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Repositories
{
    public class CommentRepository : GenericRepository<TComment>, ICommentRepository
    {
        public CommentRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
