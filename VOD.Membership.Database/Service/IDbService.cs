using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;
using VOD.Membership.Database.Interfaces;

namespace VOD.Membership.Data.Service
{
    public interface IDbService
    {
        public Task<TEntity> AddAsync<TEntity, TDto>(TDto Dto)
            where TEntity : class, IEntity
            where TDto : class;

        public Task<List<TDto>> GetAllAsync<TEntity, TDto>()
            where TDto : class
            where TEntity : class, IEntity;

        public Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity;

        public Task<bool> DeleteAsync<TEntity>(int Id)
            where TEntity : class, IEntity;

        public bool Delete<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class;

        public Task<bool> SaveChangesAsync();

        public void Update<TDto, TEntity>(int Id, TDto dto)
            where TDto : class
            where TEntity : class, IEntity;

        public Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity;
    }
}
