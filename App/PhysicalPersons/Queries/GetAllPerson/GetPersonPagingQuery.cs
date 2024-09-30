using MediatR;
using TaskAPI.App.PhysicalPersons.DTOs;

namespace TaskAPI.App.PhysicalPersons.Queries.GetAllPerson;

public class GetPersonPagingQuery: IRequest<List<PhysicalPersonDTO>>
{
    public PersonPagingParameters Parameters { get; set; }

    public GetPersonPagingQuery()
    {
        Parameters = new PersonPagingParameters();
    }
}