using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskAPI.App.PhoneNumbers.ValueObjects;

namespace TaskAPI.App.PhoneNumbers.DTOs;

public class PhoneNumberDTO
{
    public int? Id { get; set; }
    [Required]
    public int PersonId { get; set; }
    [Required]
    public PhoneNumberType Type { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Number { get; set; }

    public PhoneNumberDTO()
    {
        
    }
    
    public PhoneNumberDTO(PhoneNumber phoneNumber)
    {
        Id = phoneNumber.Id;
        PersonId = phoneNumber.PersonId;
        Type = phoneNumber.Type;
        Number = phoneNumber.Number;
    }

}