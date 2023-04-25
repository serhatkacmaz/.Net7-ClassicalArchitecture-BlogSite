using AutoMapper;
using BlogSite.Common.DTOs;
using BlogSite.Core.Entities.Base;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using BlogSite.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogSite.Service.Services
{
    public class Service<Entity, Dto> : IService<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        #region Old Method
        //private readonly IGenericRepository<T> _repository;
        //private readonly IUnitOfWork _unitOfWork;

        //public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        //{
        //    _repository = repository;
        //    _unitOfWork = unitOfWork;
        //}

        //public async Task<T> AddAsync(T entity)
        //{
        //    await _repository.AddAsync(entity);
        //    await _unitOfWork.CommitAsync();
        //    return entity;
        //}

        //public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    await _repository.AddRangeAsync(entities);
        //    await _unitOfWork.CommitAsync();
        //    return entities;
        //}

        //public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await _repository.AnyAsync(expression);
        //}

        //public async Task RemoveAsync(T entity)
        //{
        //    _repository.Remove(entity);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task RemoveRangeAsync(IEnumerable<T> entities)
        //{
        //    _repository.RemoveRange(entities);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _repository.GetAll().ToListAsync();
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    _repository.Update(entity);
        //    await _unitOfWork.CommitAsync();
        //}

        //public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        //{
        //    return _repository.Where(expression);
        //}

        //public async Task<T> GetByIdAsync(object id)
        //{
        //    return await _repository.GetByIdAsync(id);
        //}
        #endregion

        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public Service(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BlogSiteResponseDto<Dto>> AddAsync(Dto dto)
        {
            var newEntity = _mapper.Map<Entity>(dto);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<Dto>(newEntity);
            return BlogSiteResponseDto<Dto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<BlogSiteResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtoList)
        {
            var newEntities = _mapper.Map<IEnumerable<Entity>>(dtoList);
            await _repository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();

            var newDtoList = _mapper.Map<IEnumerable<Dto>>(newEntities); ;
            return BlogSiteResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, newDtoList);
        }

        public async Task<BlogSiteResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var anyEntity = await _repository.AnyAsync(expression);
            return BlogSiteResponseDto<bool>.Success(StatusCodes.Status200OK, anyEntity);
        }

        public async Task<BlogSiteResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entities);
            return BlogSiteResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public async Task<BlogSiteResponseDto<Dto>> GetByIdAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundException($"{typeof(Entity).Name}({id}) not found");

            var dto = _mapper.Map<Dto>(entity);
            return BlogSiteResponseDto<Dto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<BlogSiteResponseDto<NoContentDto>> RemoveAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                throw new NotFoundException($"{typeof(Entity).Name}({id}) not found");

            _repository.Remove(entity);

            await _unitOfWork.CommitAsync();
            return BlogSiteResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<BlogSiteResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<object> ids)
        {
            var entities = await _repository.Where(x => ids.Contains(x.Id)).ToListAsync();
            _repository.RemoveRange(entities);

            await _unitOfWork.CommitAsync();
            return BlogSiteResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<BlogSiteResponseDto<NoContentDto>> UpdateAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            _repository.Update(entity);

            await _unitOfWork.CommitAsync();
            return BlogSiteResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<BlogSiteResponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression)
        {
            var entities = await _repository.Where(expression).ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entities);
            return BlogSiteResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public BlogSiteResponseDto<int> Count(Expression<Func<Entity, bool>> expression)
        {
            var count = _repository.Count(expression);
            return BlogSiteResponseDto<int>.Success(StatusCodes.Status200OK, count);
        }

        public async Task<BlogSiteResponseDto<IEnumerable<Dto>>> GetAllWithIncludeAllAsync()
        {
            var entities = await _repository.GetAllWithIncludeAll().ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entities);

            return BlogSiteResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList);
        }

        public async Task<BlogSiteResponseDto<IEnumerable<Dto>>> GetAllWithIncludeAsync(List<Expression<Func<Entity, object>>> includeProperties)
        {
            var entities = await _repository.GetAllWithInclude(includeProperties).ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<Dto>>(entities);

            return BlogSiteResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtoList);
        }
    }
}
