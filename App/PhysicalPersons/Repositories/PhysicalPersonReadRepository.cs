using System.Data;
using Dapper;
using TaskAPI.App.PersonRelationships.DTOs;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;
using TaskAPI.App.PhysicalPersons.ValueObjects;
using TaskAPI.Persistent.Data;

namespace TaskAPI.App.PhysicalPersons.Repositories;

public class PhysicalPersonReadRepository : IPhysicalPersonReadRepository
{
    private readonly ISqlConnectionFactory _factory;

    private const string GetPersonProcedure = "GetPhysicalPersonById";//GetPhysicalPersons
    private const string GetPersonListProcedure = "GetPhysicalPersons";

    public PhysicalPersonReadRepository(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<PhysicalPersonDTO> GetAsync(int id)
    {
        using var connection = _factory.CreateConnection();
        var personDictionary = new Dictionary<int, PhysicalPersonDTO>();

        var result = await connection.QueryAsync<PhysicalPersonDTO, PhoneNumberDTO, PersonRelationshipDTO, PhysicalPersonDTO>(
            GetPersonProcedure,
            (person, phone, relationship) =>
            {
                if (!personDictionary.TryGetValue(person.Id.Value, out var physicalPerson))
                {
                    physicalPerson = person;
                    physicalPerson.PhoneNumbers = new List<PhoneNumberDTO>();
                    physicalPerson.Relationships = new List<PersonRelationshipDTO>();
                    personDictionary.Add(person.Id.Value, physicalPerson);
                }

                if (phone != null && !physicalPerson.PhoneNumbers.Any(p => p.Id == phone.Id))
                {
                    physicalPerson.PhoneNumbers.Add(phone);
                }

                if (relationship != null && !physicalPerson.Relationships.Any(r => r.Id == relationship.Id))
                {
                    physicalPerson.Relationships.Add(relationship);
                }

                return physicalPerson;
            },
            new { Id = id },
            splitOn: "Id,Id",
            commandType: CommandType.StoredProcedure);

        return personDictionary.Values.FirstOrDefault();
    }

    public async Task<List<PhysicalPersonDTO>> GetPhysicalPersonsAsync(PersonPagingParameters parameters)
    {
        using var connection = _factory.CreateConnection();
            

        var result = await connection.QueryAsync<PhysicalPersonDTO>(
            GetPersonListProcedure,
            new
            {
                SearchTerm = parameters.SearchTerm,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName,
                Gender = parameters.Gender,
                PersonalNumber = parameters.PersonalNumber,
                DateOfBirth = parameters.DateOfBirth,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            },
            commandType: CommandType.StoredProcedure);

            return result.ToList();
         
    }
}