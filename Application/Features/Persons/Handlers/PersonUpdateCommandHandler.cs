using Application.Exceptions;
using Application.Features.Persons.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
	public class PersonUpdateCommandHandler(
		IPersonRepository personRepository,
		IMapper mapper)
		: IRequestHandler<PersonUpdateCommand, Person?>
	{
		public async Task<Person?> Handle(PersonUpdateCommand command, CancellationToken cancellationToken)
		{
			var request = command.Request;

			var person = mapper.Map<Person>(request);

			var result = await personRepository.Update(person) ??
				throw new EntityNotFoundException("Could not update entity, because it doesn't exist in our database");

			return result;
		}
	}
}
