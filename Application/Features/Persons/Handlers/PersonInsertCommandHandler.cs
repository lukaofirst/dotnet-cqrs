using Application.Features.Persons.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
	public class PersonInsertCommandHandler : IRequestHandler<PersonInsertCommand, Person?>
	{
		private readonly IPersonRepository _personRepository;

		public PersonInsertCommandHandler(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}
		public async Task<Person?> Handle(PersonInsertCommand request, CancellationToken cancellationToken)
		{
			var createdPerson = new Person(request.Id, request.Name, request.Age);

			return await _personRepository.Insert(createdPerson);
		}
	}
}
