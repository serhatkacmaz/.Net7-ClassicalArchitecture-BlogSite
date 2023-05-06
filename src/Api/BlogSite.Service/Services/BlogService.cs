using AutoMapper;
using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using BlogSite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Services
{
    public class BlogService : Service<TBlog, TBlogDto>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICommentRepository _commentRepository;

        public BlogService(IGenericRepository<TBlog> repository, IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository, ICommentRepository commentRepository) : base(repository, unitOfWork, mapper)
        {
            _blogRepository = blogRepository;
            _commentRepository = commentRepository;
        }

        public async Task<BlogSiteResponseDto<List<TBlogDto>>> GetByUserIdAsync(int userId)
        {
            var list = await _blogRepository.GetByUserIdAsync(userId).ToListAsync();
            var dtoList = _mapper.Map<List<TBlogDto>>(list);

            return BlogSiteResponseDto<List<TBlogDto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public BlogSiteResponseDto<int> GetTotalViewCountByUserId(int userId)
        {
            var count = _blogRepository.GetTotalViewCountByUserId(userId);
            return BlogSiteResponseDto<int>.Success(StatusCodes.Status200OK, count);
        }

        public BlogSiteResponseDto<int> GetTotalViewCount()
        {
            var count = _blogRepository.GetTotalViewCount();
            return BlogSiteResponseDto<int>.Success(StatusCodes.Status200OK, count);
        }

        public async Task<BlogSiteResponseDto<List<TBlogDto>>> GetAllWithUser(int page, int pageSize)
        {
            var list = await _blogRepository.GetAllWithUser(page, pageSize).ToListAsync();


            var dtoList = _mapper.Map<List<TBlogDto>>(list);

            return BlogSiteResponseDto<List<TBlogDto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public async Task<BlogSiteResponseDto<TBlogDto>> GetByIdWithUser(int id)
        {
            var model = await _blogRepository.GetByIdWithUser(id);

            var commentList = new List<CommentModel>();
            var comments = await _commentRepository.GetAllByBlogId(id).ToListAsync();

            foreach (var item in comments)
            {
                commentList.Add(new CommentModel()
                {
                    Comment = item.Comment,
                    Date = item.CreatedDate,
                    UserFullName = item.User.UserName,
                    UserImg = item.User.Image
                });
            }

            var dto = _mapper.Map<TBlogDto>(model);
            dto.CommentModels = commentList;

            return BlogSiteResponseDto<TBlogDto>.Success(StatusCodes.Status200OK, dto);
        }
    }
}
