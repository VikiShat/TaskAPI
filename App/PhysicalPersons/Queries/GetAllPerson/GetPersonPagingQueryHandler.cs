using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;

namespace TaskAPI.App.PhysicalPersons.Queries.GetAllPerson;

public class GetPersonPagingQueryHandler: IRequestHandler<GetPersonPagingQuery, List<PhysicalPersonDTO>>
{
    private readonly IPhysicalPersonReadRepository _repository;

    public GetPersonPagingQueryHandler(IPhysicalPersonReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PhysicalPersonDTO>> Handle(GetPersonPagingQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetPhysicalPersonsAsync(request.Parameters);
    }
}