using MediatR;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.DeletePhoneNumber;

public class DeletePhoneNumberFromPhysicalPersonCommandHandler :IRequestHandler<DeletePhoneNumberFromPhysicalPersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public DeletePhoneNumberFromPhysicalPersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }
    public async Task Handle(DeletePhoneNumberFromPhysicalPersonCommand request, CancellationToken cancellationToken)
    {
        await _service.DeletePhoneNumberAsync(request.dto);
    }
}