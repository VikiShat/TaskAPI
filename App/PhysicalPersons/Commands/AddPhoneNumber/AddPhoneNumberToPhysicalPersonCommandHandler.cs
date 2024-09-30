using MediatR;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.AddPhoneNumber;

public class AddPhoneNumberToPhysicalPersonCommandHandler : IRequestHandler<AddPhoneNumberToPhysicalPersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public AddPhoneNumberToPhysicalPersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
        
    }
    public async Task Handle(AddPhoneNumberToPhysicalPersonCommand request, CancellationToken cancellationToken)
    {
        await _service.AddPhoneNumberAsync(request.dto);
    }
}