namespace GradeBookMicroservice.Insractructure.Repositories.Implementations;

using System.Collections.Generic;
using System.Threading.Tasks;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
public class InMemoryRepository<TEntity, TId>(IEnumerable<TEntity> entities) : IRepository<TEntity, TId> where TEntity : Entity<TId> where TId : struct
{
    private List<TEntity> _entities = entities.ToList();

    public InMemoryRepository() : this([])
    {
        
    }
    public Task<TEntity> AddAsync(TEntity entity)
    {
        _entities.Add(entity);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        return Task.CompletedTask;

    }
    public async Task DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id);
        if(entity is null)
            return;
        await DeleteAsync(entity);
    }


    public Task<IEnumerable<TEntity>> GetAllAsync() => Task.FromResult(_entities.AsEnumerable());


    public Task<TEntity?> GetByIdAsync(TId id) => Task.FromResult(_entities.FirstOrDefault(x => x.Id.Equals(id)));


    public Task UpdateAsync(TEntity entity)
    {
        var entityToUpdate = _entities.FirstOrDefault(x => x.Id.Equals(entity.Id));
        if(entityToUpdate is null)
            return Task.CompletedTask;
        var index = _entities.IndexOf(entityToUpdate);
        _entities[index] = entity;
        return Task.CompletedTask;
    }
}
