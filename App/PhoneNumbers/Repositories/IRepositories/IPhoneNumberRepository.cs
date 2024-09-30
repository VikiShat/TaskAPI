using TaskAPI.App.PhoneNumbers.ValueObjects;
using TaskAPI.Shared;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PhoneNumbers.Repositories.IRepositories;

public interface IPhoneNumberRepository : IBaseRepository<PhoneNumber>
{
    Task<List<PhoneNumber>> GetAllByPersonId(int personId);
}