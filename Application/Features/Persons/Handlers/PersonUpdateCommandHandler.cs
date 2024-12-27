using Application.Exceptions;
using Application.Features.Persons.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers;

public class PersonUpdateCommandHandler(
	IPersonRepository personRepository,
	IMapper mapper)
	: IRequestHandler<PersonUpdateCommand, Unit>
{
	public async Task<Unit> Handle(PersonUpdateCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var updatedPerson = mapper.Map<Person>(request);

		var person = await personRepository.GetById(updatedPerson.Id);

		if (person is null)
			throw new EntityNotFoundException("Could not update entity, because it doesn't exist in our database");

		await personRepository.Update(person, updatedPerson);

		return Unit.Value;
	}
}
