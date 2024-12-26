using Application.Exceptions;
using Application.Features.Persons.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
	public class PersonDeleteCommandHandler(
		IPersonRepository personRepository) : IRequestHandler<PersonDeleteCommand, bool>
	{
		public async Task<bool> Handle(PersonDeleteCommand command, CancellationToken cancellationToken)
		{
			var id = command.Id;

			var result = await personRepository.Delete(id);

			if (!result)
				throw new EntityNotFoundException($"Entity with id: [{id}] wasn't found");

			return result;
		}
	}
}
