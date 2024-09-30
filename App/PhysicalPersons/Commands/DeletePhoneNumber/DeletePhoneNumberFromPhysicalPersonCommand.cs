using MediatR;
using TaskAPI.App.PhoneNumbers.DTOs;

namespace TaskAPI.App.PhysicalPersons.Commands.DeletePhoneNumber;

public record DeletePhoneNumberFromPhysicalPersonCommand(PhoneNumberDTO dto) : IRequest;