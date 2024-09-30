using MediatR;
using TaskAPI.App.PersonRelationships.ValueObjects;

namespace TaskAPI.App.PhysicalPersons.Commands.AddRelationship;

public record AddRelationshipToPersonCommand(int PersonId, int SecondPersonId, RelationType Type): IRequest;