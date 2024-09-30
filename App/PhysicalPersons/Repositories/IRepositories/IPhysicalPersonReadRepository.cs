using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.Repositories.IRepositories;

public interface IPhysicalPersonReadRepository
{
    Task<PhysicalPersonDTO> GetAsync(int id);

    Task<List<PhysicalPersonDTO>> GetPhysicalPersonsAsync(PersonPagingParameters parameters);
}