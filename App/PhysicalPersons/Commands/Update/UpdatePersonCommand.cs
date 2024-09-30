using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.Commands.Update;

public record UpdatePersonCommand : IRequest
{
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Zა-ჰ]+$")]  
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Zა-ჰ]+$")]  
    public string LastName { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    [RegularExpression(@"^\d{11}$")]  
    public string PersonalNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
