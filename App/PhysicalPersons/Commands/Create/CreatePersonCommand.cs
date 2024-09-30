using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskAPI.App.PhysicalPersons.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.Commands.Create;

public record CreatePersonCommand() : IRequest
{
    [Required(ErrorMessage="FirstName name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimum length is 2, maximum is 50")]
    [RegularExpression(@"^(?:(?:[a-zA-Z]+)|(?:[ა-ჰ]+))$", ErrorMessage = "Should contain only letters of the Georgian or Latin alphabet.")]  
    public string FirstName { get; set; }

    [Required(ErrorMessage="LastName name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimum length is 2, maximum is 50")]
    [RegularExpression(@"^(?:(?:[a-zA-Z]+)|(?:[ა-ჰ]+))$", ErrorMessage = "Should contain only letters of the Georgian or Latin alphabet.")]  
    public string LastName { get; set; }

    [Required(ErrorMessage="Gender name is required. Male - 0, Female - 1.")]
    [EnumDataType(typeof(Gender),ErrorMessage="Male - 0, Female - 1.")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage="PersonalNumber name is required. Length must be 11. Only digits.")]
    [StringLength(11, MinimumLength = 11)]
    [RegularExpression(@"^\d{11}$")]  
    public string PersonalNumber { get; set; }

    [Required(ErrorMessage="DateOfBirth name is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
}