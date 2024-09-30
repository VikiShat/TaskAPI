using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using TaskAPI.App.PersonRelationships.DTOs;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhysicalPersons.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.DTOs;

public class PhysicalPersonDTO
{
    public int? Id { get; set; }   
    public string FirstName { get; set; }
 
    public string LastName { get; set; }
 
    public Gender Gender { get; set; }
 
    public string PersonalNumber { get; set; }
 
    public DateTime DateOfBirth { get; set; }

    public List<PhoneNumberDTO>? PhoneNumbers { get; set; } = new();
    public List<PersonRelationshipDTO>? Relationships { get; set; } = new();

    public PhysicalPersonDTO()
    {
        
    }
    public PhysicalPersonDTO(PhysicalPerson entity)
    {
        Id = entity.Id;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
        Gender = (Gender)entity.Gender;
        PersonalNumber = entity.PersonalNumber;
        DateOfBirth = entity.DateOfBirth;
        if(!entity.PhoneNumbers.IsNullOrEmpty()) PhoneNumbers = new List<PhoneNumberDTO>( entity.PhoneNumbers.Select(x => new PhoneNumberDTO(x)).ToList());
        
    }
    public PhysicalPersonDTO(int? id,string firstName,string lastName,Gender gender,string personalNumber,DateTime dateOfBirth)
    {
        Id = id?? null;
        
        bool isLatin = Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
        bool isGeorgian = Regex.IsMatch(firstName, @"^[ა-ჰ]+$") && Regex.IsMatch(firstName, @"^[ა-ჰ]+$");

        if (!isLatin && !isGeorgian)
        {
            throw new ArgumentException("The first and last name must be written in the same language.");
        }
        FirstName = firstName;
        LastName =lastName;
        Gender =gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth; 
    }

}