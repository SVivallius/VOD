using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;
using VOD.Membership.Data.Context;
using VOD.Membership.Database.Interfaces;

namespace VOD.Membership.Data.Service;

public class VOD_Service : IDbService
{
    private readonly IMapper _mapper;
    private readonly VOD_Context _db;

    public VOD_Service(IMapper mapper, VOD_Context db)
    {
        _mapper = mapper;
        _db = db;
    }

    public async Task<bool> SaveChangesAsync()
    {
        int set = await _db.SaveChangesAsync();
        return set > 0;
    }

    async Task<TEntity> IDbService.AddAsync<TEntity, TDto>(TDto Dto)
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(Dto);
        await _db.AddAsync(entity);
        return entity;
    }


    bool IDbService.Delete<TReferenceEntity, TDto>(TDto dto)
    {
        try
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            if (entity != null)
            {
                _db.Remove(entity);
                return true;
            }
            else return false;
        }
        catch
        {
            throw;
        }
    }

    async Task<bool> IDbService.DeleteAsync<TEntity>(int Id)
    {
        try
        {
            var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == Id);
            if (entity != null)
            {
                _db.Remove(entity);
                return true;
            }
            else return false;
        }
        catch
        {
            throw;
        }
    }

    async Task<List<TDto>> IDbService.GetAllAsync<TEntity, TDto>()
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    async Task<TEntity> IDbService.GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
        return entity;
    }

    void IDbService.Update<TDto, TEntity>(int Id, TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = Id;
        _db.Set<TEntity>().Update(entity);
    }

    async Task<bool> IDbService.AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }
}
