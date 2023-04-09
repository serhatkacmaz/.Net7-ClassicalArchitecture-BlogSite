using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class ImageRepository : GenericRepository<TImage>, IImageRepository
    {
        public ImageRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
