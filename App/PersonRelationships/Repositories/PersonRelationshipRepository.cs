using Microsoft.EntityFrameworkCore;
using TaskAPI.App.PersonRelationships.Repositories.IRepositories;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PersonRelationships.Repositories;

public class PersonRelationshipRepository : BaseRepository<PersonRelationship>,IPersonRelationshipRepository
{
    public PersonRelationshipRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<List<PersonRelationship>> GetAllByFirstPersonIdAsync(int id)
    {
        return await _db.PersonRelationships.Where(x => x.FirstPersonId == id).ToListAsync();
    }
}