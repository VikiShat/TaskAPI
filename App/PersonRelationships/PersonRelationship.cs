using TaskAPI.App.PersonRelationships.ValueObjects;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.PersonRelationships;

public class PersonRelationship : BaseEntity
{
    public int FirstPersonId { get; set; }
    public int SecondPersonId { get; set; }
    public RelationType Type { get; set; }

    private PersonRelationship(int firstPersonId, int secondPersonId, RelationType type)
    {
        FirstPersonId = firstPersonId;
        SecondPersonId = secondPersonId;
        Type = type;
    }

    public static PersonRelationship Create(int firstPersonId, int secondPersonId, RelationType type)
    {
        return new PersonRelationship(firstPersonId, secondPersonId, type);
    }
    
     
}