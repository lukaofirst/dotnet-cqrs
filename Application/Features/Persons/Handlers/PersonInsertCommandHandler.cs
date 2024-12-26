using Application.Exceptions;
using Application.Features.Persons.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
	public class PersonInsertCommandHandler(
		IPersonRepository personRepository,
		IMapper mapper)
		: IRequestHandler<PersonInsertCommand, Person?>
	{
		public async Task<Person?> Handle(PersonInsertCommand command, CancellationToken cancellationToken)
		{
			var request = command.Request;

			var person = mapper.Map<Person>(request);

			var result = await personRepository.Insert(person) ??
				throw new EntityAlreadyExistException("Could not insert entity, because it already exist in our database");

			return result;
		}
	}
}
