using AutoMapper;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class CommentService : Service<TComment, TCommentDto>, ICommentService
    {
        public CommentService(IGenericRepository<TComment> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
