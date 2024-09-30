using TaskAPI.App.PhoneNumbers;
using TaskAPI.App.PhysicalPersons.ValueObjects;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PhysicalPersons;

public class PhysicalPerson : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Gender Gender { get; private set; }

    public string PersonalNumber { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public List<PhoneNumber> PhoneNumbers { get; set; } 
 
    private PhysicalPerson(string firstName, string lastName, Gender gender, string personalNumber, DateTime dateOfBirth)
    {
        Validate(firstName, lastName, personalNumber, dateOfBirth);   
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
    } 
    public static PhysicalPerson Create(string firstName, string lastName, Gender gender, string personalNumber, DateTime dateOfBirth)
    {
        return new PhysicalPerson(firstName, lastName, gender, personalNumber, dateOfBirth);
    }
 
    public void Update(string firstName, string lastName, Gender gender, string personalNumber, DateTime dateOfBirth)
    {
        Validate(firstName, lastName, personalNumber, dateOfBirth);  
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
    }
 
    private bool IsValidName(string name)
    {
        return name.All(c => char.IsLetter(c) && (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= 'ა' && c <= 'ჰ'));
    }
    private void Validate(string firstName, string lastName, string personalNumber, DateTime dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 2 || firstName.Length > 50 || !IsValidName(firstName))
        {
            throw new ArgumentException("The name must contain only letters of the Georgian or Latin alphabet and be from 2 to 50 characters long.");
        }

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length < 2 || lastName.Length > 50 || !IsValidName(lastName))
        {
            throw new ArgumentException("The surname must contain only letters of the Georgian or Latin alphabet and be from 2 to 50 characters long.");
        }

        if (personalNumber.Length != 11 || !personalNumber.All(char.IsDigit))
        {
            throw new ArgumentException("The personal number must contain 11 digits.");
        }

        if ((DateTime.Now.Year - dateOfBirth.Year) < 18)
        {
            throw new ArgumentException("Must be at least 18 years old.");
        }
    }
}
