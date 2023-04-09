using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogSiteContext _context;

        public UnitOfWork(BlogSiteContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
