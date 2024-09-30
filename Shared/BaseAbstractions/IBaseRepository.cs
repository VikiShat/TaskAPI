namespace TaskAPI.Shared.BaseAbstractions;

public interface IBaseRepository<TEntity>  
    where TEntity :  BaseEntity  
{
    Task CreateAsync(TEntity entity);
    Task CreateAsync(IEnumerable<TEntity> entities);
    Task<TEntity> GetAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    void Update(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void Delete(IEnumerable<TEntity> entities);
}