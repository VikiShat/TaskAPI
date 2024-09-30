using MediatR;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.AddRelationship;

public class AddRelationshipToPersonCommandHandler : IRequestHandler<AddRelationshipToPersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public AddRelationshipToPersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }
    public async Task Handle(AddRelationshipToPersonCommand request, CancellationToken cancellationToken)
    {
        await _service.AddRelationship(request.PersonId, request.SecondPersonId, request.Type);
    }
}