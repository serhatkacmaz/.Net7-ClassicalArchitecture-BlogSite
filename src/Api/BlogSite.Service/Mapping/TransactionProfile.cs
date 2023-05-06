using AutoMapper;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.DTOs.UserBase;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Service.Mapping
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TComment, TCommentDto>().ReverseMap();
            CreateMap<TMovement, TMovementDto>().ReverseMap();
            CreateMap<TBlog, TBlogDto>()
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                  .ForMember(dest => dest.UserImg, opt => opt.MapFrom(src => src.User.Image));

            CreateMap<TBlogDto, TBlog>();
        }
    }
}
