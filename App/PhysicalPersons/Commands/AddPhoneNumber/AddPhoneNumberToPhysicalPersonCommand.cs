using MediatR;
using TaskAPI.App.PhoneNumbers.DTOs;

namespace TaskAPI.App.PhysicalPersons.Commands.AddPhoneNumber;

public record AddPhoneNumberToPhysicalPersonCommand(PhoneNumberDTO dto) : IRequest;