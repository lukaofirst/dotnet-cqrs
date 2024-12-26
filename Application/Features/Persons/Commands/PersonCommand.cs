using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Commands
{
	public abstract class PersonCommand(PersonDTO request) : IRequest<Person>
	{
		public PersonDTO Request { get; set; } = request;
	}
}
