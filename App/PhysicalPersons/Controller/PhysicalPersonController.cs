using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.App.PhoneNumbers.DTOs;
using TaskAPI.App.PhysicalPersons.Commands.AddPhoneNumber;
using TaskAPI.App.PhysicalPersons.Commands.AddRelationship;
using TaskAPI.App.PhysicalPersons.Commands.Create;
using TaskAPI.App.PhysicalPersons.Commands.Delete;
using TaskAPI.App.PhysicalPersons.Commands.DeletePhoneNumber;
using TaskAPI.App.PhysicalPersons.Commands.DeleteRelationship;
using TaskAPI.App.PhysicalPersons.Commands.Update;
using TaskAPI.App.PhysicalPersons.Queries.Get;
using TaskAPI.App.PhysicalPersons.Queries.GetAllPerson;
using TaskAPI.App.PhysicalPersons.Queries.GetForUpdate;
using TaskAPI.Shared;

namespace TaskAPI.App.PhysicalPersons.Controller;
[Route("api/[controller]/[action]")]
[ApiController]
public class PhysicalPersonController : ControllerBase
{
    protected readonly IMediator _mediator;

    public PhysicalPersonController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost] 
    public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }
    [HttpPost] 
    public async Task<IActionResult> Update([FromBody] UpdatePersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }
    [HttpPost] 
    public async Task<IActionResult> AddPhone([FromBody] PhoneNumberDTO request)
    {
        await _mediator.Send(new AddPhoneNumberToPhysicalPersonCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }
    [HttpPost] 
    public async Task<IActionResult> AddRelationship([FromBody] AddRelationshipToPersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }
    
    [HttpDelete] 
    public async Task<IActionResult> Delete([FromBody] DeletePersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }
    [HttpDelete] 
    public async Task<IActionResult> DeletePhone([FromBody] PhoneNumberDTO request)
    {
        await _mediator.Send(new DeletePhoneNumberFromPhysicalPersonCommand(request));
        return Ok(ServiceResponse.SucceededInstance());
    }
    [HttpDelete] 
    public async Task<IActionResult> DeleteRelationship([FromBody] DeleteRelationshipToPersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(ServiceResponse.SucceededInstance());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetForUpdate(int id)
    {
        return Ok(ServiceResponse.SucceededInstance(await _mediator.Send(new GetPersonForUpdateQuery(id))));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(ServiceResponse.SucceededInstance(await _mediator.Send(new GetPersonByIdQuery(id))));
    }
    [HttpGet]
    public async Task<IActionResult> GetPersonPaging([FromQuery]GetPersonPagingQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(ServiceResponse.SucceededInstance(result));
    }
}