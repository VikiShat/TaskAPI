using TaskAPI.App.PhysicalPersons.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.DTOs;

public class PersonPagingParameters
{
    public string? SearchTerm { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender { get; set; }
    public string? PersonalNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}