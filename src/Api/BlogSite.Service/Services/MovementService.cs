using AutoMapper;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class MovementService : Service<TMovement, TMovementDto>, IMovementService
    {
        public MovementService(IGenericRepository<TMovement> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
