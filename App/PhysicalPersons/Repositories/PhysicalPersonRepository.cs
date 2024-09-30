using Microsoft.EntityFrameworkCore;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PhysicalPersons.Repositories;

public class PhysicalPersonRepository :BaseRepository<PhysicalPerson>, IPhysicalPersonRepository
{
    public PhysicalPersonRepository(ApplicationDbContext db) : base(db)
    {
    }

    public override async Task<PhysicalPerson> GetAsync(int id)
    {
        return await _db.PhysicalPersons.Include(x => x.PhoneNumbers).FirstOrDefaultAsync(x=>x.Id ==id);
    }
}