using BlogSite.Core.DTOs;
using BlogSite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Services
{
    public interface IService<Entity, Dto> where Entity : BaseEntity<object> where Dto : class
    {
        Task<BlogSiteResponseDto<Dto>> GetByIdAsync(object id);
        Task<BlogSiteResponseDto<IEnumerable<Dto>>> GetAllAsync();

        Task<BlogSiteResponseDto<Dto>> AddAsync(Dto dtoList);
        Task<BlogSiteResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> entities);

        Task<BlogSiteResponseDto<NoContentDto>> UpdateAsync(Dto dto);

        Task<BlogSiteResponseDto<NoContentDto>> RemoveAsync(object id);
        Task<BlogSiteResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<object> ids);

        Task<BlogSiteResponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression);
        Task<BlogSiteResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
    }
}
