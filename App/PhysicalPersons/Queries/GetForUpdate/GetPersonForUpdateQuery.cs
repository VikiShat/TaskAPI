using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;

namespace TaskAPI.App.PhysicalPersons.Queries.GetForUpdate;

public record GetPersonForUpdateQuery(int Id):IRequest<PhysicalPersonDTO>;