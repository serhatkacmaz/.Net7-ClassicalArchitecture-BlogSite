using BlogSite.Core.Entities.Master;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<MCategory>, ICategoryRepository
    {
        public CategoryRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
