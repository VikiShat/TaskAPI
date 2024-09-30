using Microsoft.EntityFrameworkCore;
using TaskAPI.Persistent.Data;

namespace TaskAPI.Shared.BaseAbstractions;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _db;

    public BaseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
    }

    public virtual async Task CreateAsync(IEnumerable<TEntity> entities)
    {
        await _db.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _db.Set<TEntity>().ToListAsync();
    }

    public virtual void Update(TEntity entity)
    {
        _db.Set<TEntity>().Update(entity);
    }

    public virtual void Update(IEnumerable<TEntity> entities)
    {
        _db.Set<TEntity>().UpdateRange(entities);
    }

    public virtual void Delete(TEntity entity)
    {
        _db.Set<TEntity>().Remove(entity);
    }

    public virtual void Delete(IEnumerable<TEntity> entities)
    {
        _db.Set<TEntity>().RemoveRange(entities);
    }

    public virtual async Task<TEntity> GetAsync(int id)
    {
        return await _db.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}