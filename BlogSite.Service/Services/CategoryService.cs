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
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IGenericRepository<MCategory> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> LastCategoryPKAsync()
        {
            var entity = await _categoryRepository.LastCategoryPKAsync();
            return entity?.Id ?? 0;
        }
    }
}
