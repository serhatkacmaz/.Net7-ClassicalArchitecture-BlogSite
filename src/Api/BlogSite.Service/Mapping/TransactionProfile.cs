using AutoMapper;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;

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
                .ForMember(dest => dest.UserTitle, opt => opt.MapFrom(src => src.User.Title))
                .ForMember(dest => dest.UserAbout, opt => opt.MapFrom(src => src.User.About))
                .ForMember(dest => dest.UserImg, opt => opt.MapFrom(src => src.User.Image));

            CreateMap<TBlogDto, TBlog>();
        }
    }
}
