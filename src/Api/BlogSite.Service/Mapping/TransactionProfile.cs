using AutoMapper;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Service.Mapping
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TBlog, TBlogDto>().ReverseMap();
            CreateMap<TComment, TCommentDto>().ReverseMap();
            CreateMap<TImage, TImageDto>().ReverseMap();
            CreateMap<TMovement, TMovementDto>().ReverseMap();
        }
    }
}
