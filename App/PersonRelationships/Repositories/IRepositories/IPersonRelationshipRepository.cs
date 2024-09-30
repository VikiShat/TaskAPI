using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PersonRelationships.Repositories.IRepositories;

public interface IPersonRelationshipRepository : IBaseRepository<PersonRelationship>
{
    Task<List<PersonRelationship>> GetAllByFirstPersonIdAsync(int id);
}