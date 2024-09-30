using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;

namespace TaskAPI.App.PhysicalPersons.Queries.Get;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery,PhysicalPersonDTO>
{
    private readonly IPhysicalPersonReadRepository _repository;

    public GetPersonByIdQueryHandler(IPhysicalPersonReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhysicalPersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(request.Id);
    }
}