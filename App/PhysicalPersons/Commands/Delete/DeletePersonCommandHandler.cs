using MediatR;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.Delete;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public DeletePersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }
    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Id);
    }
}