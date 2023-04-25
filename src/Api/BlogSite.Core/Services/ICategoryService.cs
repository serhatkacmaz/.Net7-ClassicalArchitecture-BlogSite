using BlogSite.Common.DTOs.Master;
using BlogSite.Core.Entities.Master;

namespace BlogSite.Core.Services
{
    public interface ICategoryService : IService<MCategory, MCategoryDto>
    {
        Task<int> LastCategoryPKAsync();
    }
}
