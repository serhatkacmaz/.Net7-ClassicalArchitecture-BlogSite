using AutoMapper;
using BlogSite.Core.DTOs.Master;
using BlogSite.Core.Entities.Master;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class CategoryService : Service<MCategory, MCategoryDto>, ICategoryService
    {
        public CategoryService(IGenericRepository<MCategory> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
