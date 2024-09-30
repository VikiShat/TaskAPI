using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;

namespace TaskAPI.App.PhysicalPersons.Queries.Get;

public record GetPersonByIdQuery(int Id):IRequest<PhysicalPersonDTO>;