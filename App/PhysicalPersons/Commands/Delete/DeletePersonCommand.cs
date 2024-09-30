using MediatR;

namespace TaskAPI.App.PhysicalPersons.Commands.Delete;

public record DeletePersonCommand(int Id):IRequest
;