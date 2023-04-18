using BlogSite.Core.Entities.Master;
using BlogSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<MCategory>, ICategoryRepository
    {
        public CategoryRepository(BlogSiteContext context) : base(context)
        {
        }

        public async Task<MCategory> LastCategoryPKAsync()
        {
            return await _context.MCategories.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
