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

		var personExist = await personRepository.GetByName(request.Name);

		if (personExist is not null)
			throw new EntityAlreadyExistException("Entity already exist in database");

		var person = mapper.Map<Person>(request);

		await personRepository.Insert(person);

		return Unit.Value;
	}
}
