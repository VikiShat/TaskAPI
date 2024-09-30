using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;

namespace TaskAPI.App.PhysicalPersons.Queries.GetForUpdate;

public class GetPersonForUpdateQueryHandler : IRequestHandler<GetPersonForUpdateQuery,PhysicalPersonDTO>
{
    private readonly IPhysicalPersonRepository _repository;

    public GetPersonForUpdateQueryHandler(IPhysicalPersonRepository repository)
    {
        _repository = repository;
    }
    public async Task<PhysicalPersonDTO> Handle(GetPersonForUpdateQuery request, CancellationToken cancellationToken)
    {
        var person =await _repository.GetAsync(request.Id);
        if (person == null) throw new Exception("Person does not found with given Id");

       return new PhysicalPersonDTO(person);
    }
}