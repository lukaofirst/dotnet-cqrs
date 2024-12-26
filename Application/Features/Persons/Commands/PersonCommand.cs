using Application.DTOs;
using MediatR;

namespace Application.Features.Persons.Commands
{
	public abstract class PersonCommand(PersonDTO request) : IRequest<Unit>
	{
		public PersonDTO Request { get; set; } = request;
	}
}
