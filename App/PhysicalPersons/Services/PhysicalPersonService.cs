using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskAPI.App.PersonRelationships;
using TaskAPI.App.PersonRelationships.Repositories.IRepositories;
using TaskAPI.App.PersonRelationships.ValueObjects;
using TaskAPI.App.PhoneNumbers;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhoneNumbers.Repositories.IRepositories;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;
using TaskAPI.App.PhysicalPersons.Services.IServices;
using TaskAPI.Shared;

namespace TaskAPI.App.PhysicalPersons.Services;

public class PhysicalPersonService : IPhysicalPersonService
{
    private readonly IPhysicalPersonRepository _personRepository;
    private readonly IPhoneNumberRepository _numberRepository;
    private readonly IPersonRelationshipRepository _relationshipRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhysicalPersonService(IPhysicalPersonRepository personRepository, IUnitOfWork unitOfWork, IPhoneNumberRepository numberRepository, IPersonRelationshipRepository relationshipRepository)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
        _numberRepository = numberRepository;
        _relationshipRepository = relationshipRepository;
    }
    public async Task CreateAsync(PhysicalPersonDTO dto)
    {
        var entity =
            PhysicalPerson.Create(dto.FirstName, dto.LastName, dto.Gender, dto.PersonalNumber, dto.DateOfBirth);
        await _personRepository.CreateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddPhoneNumberAsync(PhoneNumberDTO dto)
    {
        var person = await _personRepository.GetAsync(dto.PersonId);

        if (person == null) throw new Exception("Person does not found with given Id");
 
        var phoneNumber = PhoneNumber.Create(dto);
 
        person.PhoneNumbers.Add(phoneNumber);
        
        _personRepository.Update(person);
        await _numberRepository.CreateAsync(phoneNumber);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeletePhoneNumberAsync(PhoneNumberDTO dto)
    {
        var person = await _personRepository.GetAsync(dto.PersonId);

        if (person == null) throw new Exception("Person does not found with given Id");
        
        var phoneNumber = person.PhoneNumbers.FirstOrDefault(p => p.Id == dto.Id);

        if (phoneNumber == null) throw new Exception("Phone number does not found with given Id");
 
        person.PhoneNumbers.Remove(phoneNumber);
 
        _personRepository.Update(person);
        _numberRepository.Delete(phoneNumber);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(PhysicalPersonDTO dto)
    {
        var person = await _personRepository.GetAsync(dto.Id.Value);
        if (person == null) throw new Exception("Person does not found with given Id");

        person.Update(dto.FirstName,dto.LastName,dto.Gender,dto.PersonalNumber,dto.DateOfBirth);
        
        _personRepository.Update(person);
        await _unitOfWork.SaveAsync();


    }

    public async Task DeleteAsync(int id)
    {
        var person = await _personRepository.GetAsync(id);
        if (person == null) throw new Exception("Person does not found with given Id");
        
        _personRepository.Delete(person);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddRelationship(int personId, int otherPersonId, RelationType type)
    {
        var person = await _personRepository.GetAsync(personId);
        if (person == null) throw new Exception("Person does not found with given Id");
        
        var secondPerson = await _personRepository.GetAsync(otherPersonId);
        if (person == null) throw new Exception("Person does not found with given Id");

        var relationship = PersonRelationship.Create(person.Id, secondPerson.Id, type);

        await _relationshipRepository.CreateAsync(relationship);
        await _unitOfWork.SaveAsync();

    }

    public async Task DeleteRelationship(int personId, int otherPersonId)
    {
        var person = await _personRepository.GetAsync(personId);
        if (person == null) throw new Exception("Person does not found with given Id");

        var allRelationships = await _relationshipRepository.GetAllByFirstPersonIdAsync(person.Id);

        var relationship = allRelationships.FirstOrDefault(x => x.SecondPersonId == otherPersonId);
        if(relationship == null)throw new Exception("Relationship does not found with given Id");
        
        _relationshipRepository.Delete(relationship);
        await _unitOfWork.SaveAsync();
    }
}