using AutoMapper;
using BlogSite.Core.DTOs.Master;
using BlogSite.Core.Entities.Master;

namespace BlogSite.Service.Mapping
{
    public class MasterProfile : Profile
    {
        public MasterProfile()
        {
            CreateMap<MCategory, MCategoryDto>().ReverseMap();
        }
    }
}
