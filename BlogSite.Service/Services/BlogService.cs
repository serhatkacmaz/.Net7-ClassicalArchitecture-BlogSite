using AutoMapper;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace BlogSite.Service.Services
{
    public class BlogService : Service<TBlog, TBlogDto>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IGenericRepository<TBlog> repository, IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository) : base(repository, unitOfWork, mapper)
        {
            _blogRepository = blogRepository;
        }

        public BlogSiteResponseDto<int> GetTotalViewCount()
        {
            var count = _blogRepository.GetTotalViewCount();
            return BlogSiteResponseDto<int>.Success(StatusCodes.Status200OK, count);
        }
    }
}
