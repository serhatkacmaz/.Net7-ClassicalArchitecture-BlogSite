using AutoMapper;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class BlogService : Service<TBlog, TBlogDto>, IBlogService
    {
        public BlogService(IGenericRepository<TBlog> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
