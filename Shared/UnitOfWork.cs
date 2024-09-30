using TaskAPI.Persistent.Data;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.Shared;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db; 
    public UnitOfWork(ApplicationDbContext db )
    {
        _db = db; 
    }
    public async Task<int> SaveAsync()
    {
        var result =  await _db.SaveChangesAsync();
       
        
        return result;
    }
   
}