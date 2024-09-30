using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.Update;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public UpdatePersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }
    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        await _service.UpdateAsync(new PhysicalPersonDTO(request.Id,request.FirstName, request.LastName, request.Gender,
            request.PersonalNumber, request.DateOfBirth));
    }
}