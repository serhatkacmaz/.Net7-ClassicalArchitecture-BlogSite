using BlogSite.Core.Entities.Master;
using BlogSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<MCategory>, ICategoryRepository
    {
        public CategoryRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
