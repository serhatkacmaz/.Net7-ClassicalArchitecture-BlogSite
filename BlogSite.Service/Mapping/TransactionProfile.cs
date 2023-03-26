using AutoMapper;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
