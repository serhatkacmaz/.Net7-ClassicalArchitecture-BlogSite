using AutoMapper;
using BlogSite.Core.DTOs.Master;
using BlogSite.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
