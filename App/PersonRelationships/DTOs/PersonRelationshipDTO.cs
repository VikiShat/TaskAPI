using TaskAPI.App.PersonRelationships.ValueObjects;

namespace TaskAPI.App.PersonRelationships.DTOs;

public class PersonRelationshipDTO
{
    public int Id { get; set; }
    public int FirstPersonId { get; set; }
    public int SecondPersonId { get; set; }
    public RelationType Type { get; set; }

    public PersonRelationshipDTO()
    {
        
    }
    public PersonRelationshipDTO(PersonRelationship entity)
    {
        Id = entity.Id;
        FirstPersonId = entity.FirstPersonId;
        SecondPersonId = entity.SecondPersonId;
        Type = entity.Type;
    }

}