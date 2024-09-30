using MediatR;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.DeleteRelationship;

public class DeleteRelationshipToPersonCommandHandler : IRequestHandler<DeleteRelationshipToPersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public DeleteRelationshipToPersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }
    public async Task Handle(DeleteRelationshipToPersonCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteRelationship(request.PersonId, request.SecondPersonId);
    }
}