using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhoneNumbers.ValueObjects;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PhoneNumbers;

public class PhoneNumber : BaseEntity
{ 
    public int PersonId { get; private set; }
    public PhoneNumberType Type { get; set; }
    public string Number { get; set; }

    private PhoneNumber(int personId,PhoneNumberType type,string number)
    {
        PersonId = personId;
        Type = type;
        Number = number;
    }

    public static PhoneNumber Create(PhoneNumberDTO dto)
    {
        return new PhoneNumber(dto.PersonId, dto.Type, dto.Number);
    }
}