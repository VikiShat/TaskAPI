using TaskAPI.App.PersonRelationships.ValueObjects;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhysicalPersons.DTOs;

namespace TaskAPI.App.PhysicalPersons.Services.IServices;

public interface IPhysicalPersonService
{
    Task CreateAsync(PhysicalPersonDTO dto);
    Task AddPhoneNumberAsync(PhoneNumberDTO dto);
    Task DeletePhoneNumberAsync(PhoneNumberDTO dto);
    Task UpdateAsync(PhysicalPersonDTO dto);
    Task DeleteAsync(int id);
    Task AddRelationship(int personId,int otherPersonId, RelationType type);
    Task DeleteRelationship(int personId, int otherPersonId);
}