using Application.Exceptions;
using Application.Features.Persons.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers;

public class PersonInsertCommandHandler(
	IPersonRepository personRepository,
	IMapper mapper)
	: IRequestHandler<PersonInsertCommand, Unit>
{
	public async Task<Unit> Handle(PersonInsertCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var person = mapper.Map<Person>(request);

		var personExist = await personRepository.GetById(person.Id);

		if (personExist is not null)
			throw new EntityAlreadyExistException("Entity already exist in our database");

		await personRepository.Insert(person);

		return Unit.Value;
	}
}
