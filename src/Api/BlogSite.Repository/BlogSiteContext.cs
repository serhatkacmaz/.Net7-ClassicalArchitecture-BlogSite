using BlogSite.Core.Entities.Base;
using BlogSite.Core.Entities.Master;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<TMovement> TMovements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }

                    }
                }

            }
        }

    }
}
