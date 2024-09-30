using Microsoft.EntityFrameworkCore;
using TaskAPI.App.PhoneNumbers.Repositories.IRepositories;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PhoneNumbers.Repositories;

public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
{
    public PhoneNumberRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<List<PhoneNumber>> GetAllByPersonId(int personId)
    {
        return await _db.PhoneNumbers.Where(x => x.PersonId == personId).ToListAsync();
    }
}