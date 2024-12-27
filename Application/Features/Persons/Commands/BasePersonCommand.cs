using Application.DTOs;
using MediatR;

namespace Application.Features.Persons.Commands;

public abstract class BasePersonCommand(PersonDTO request) : IRequest<Unit>
{
	public PersonDTO Request { get; set; } = request;
}
