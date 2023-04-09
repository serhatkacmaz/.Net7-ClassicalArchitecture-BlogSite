using BlogSite.Core.DTOs.Master;
using BlogSite.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Services
{
    public interface ICategoryService : IService<MCategory, MCategoryDto>
    {
    }
}
