using MediatR;

namespace TaskAPI.App.PhysicalPersons.Commands.DeleteRelationship;

public record   DeleteRelationshipToPersonCommand(int PersonId, int SecondPersonId): IRequest;