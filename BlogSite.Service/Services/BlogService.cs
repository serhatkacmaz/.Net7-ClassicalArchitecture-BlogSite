using AutoMapper;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Services
{
    public class BlogService : Service<TBlog, TBlogDto>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IGenericRepository<TBlog> repository, IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository) : base(repository, unitOfWork, mapper)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogSiteResponseDto<List<TBlogDto>>> GetByUserIdAsync(int userId)
        {
            var list = await _blogRepository.GetByUserIdAsync(userId).ToListAsync();
            var dtoList = _mapper.Map<List<TBlogDto>>(list);

            return BlogSiteResponseDto<List<TBlogDto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public BlogSiteResponseDto<int> GetTotalViewCount()
        {
            var count = _blogRepository.GetTotalViewCount();
            return BlogSiteResponseDto<int>.Success(StatusCodes.Status200OK, count);
        }
    }
}
