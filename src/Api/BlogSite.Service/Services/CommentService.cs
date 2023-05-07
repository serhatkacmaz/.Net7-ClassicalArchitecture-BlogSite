using AutoMapper;
using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Services
{
    public class CommentService : Service<TComment, TCommentDto>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(IGenericRepository<TComment> repository, IUnitOfWork unitOfWork, IMapper mapper, ICommentRepository commentRepository) : base(repository, unitOfWork, mapper)
        {
            _commentRepository = commentRepository;
        }

        public async Task<BlogSiteResponseDto<List<TCommentDto>>> GetAllByBlogIdAndUserId(int blogId, int userId)
        {
            var list = await _commentRepository.GetAllByBlogIdAndUserId(blogId, userId).ToListAsync();
            var dtoList = _mapper.Map<List<TCommentDto>>(list);

            return BlogSiteResponseDto<List<TCommentDto>>.Success(StatusCodes.Status200OK, dtoList);
        }
    }
}
