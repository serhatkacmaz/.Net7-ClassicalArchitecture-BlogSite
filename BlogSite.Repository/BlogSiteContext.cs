using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Master;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository
{
    public class BlogSiteContext : DbContext
    {
        public BlogSiteContext(DbContextOptions<BlogSiteContext> options) : base(options)
        {
        }

        public DbSet<MCategory> MCategories { get; set; }
        public DbSet<TBlog> TBlogs { get; set; }
        public DbSet<TComment> TComments { get; set; }
        public DbSet<TImage> TImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {

        }

        private void PrepareAddedEntities(IEnumerable<IBaseEntity> entities)
        {

        }
    }
}
