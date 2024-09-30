using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Services.IServices;

namespace TaskAPI.App.PhysicalPersons.Commands.Create;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
{
    private readonly IPhysicalPersonService _service;

    public CreatePersonCommandHandler(IPhysicalPersonService service)
    {
        _service = service;
    }

    public async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(new PhysicalPersonDTO(null,request.FirstName, request.LastName, request.Gender,
            request.PersonalNumber, request.DateOfBirth));
    }
}