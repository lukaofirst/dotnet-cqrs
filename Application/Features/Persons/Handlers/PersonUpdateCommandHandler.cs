using Application.Features.Persons.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
    public class PersonUpdateCommandHandler : IRequestHandler<PersonUpdateCommand, Person?>
    {
        private readonly IPersonRepository _personRepository;

        public PersonUpdateCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person?> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            var updatedPerson = new Person(request.Id, request.Name, request.Age);

            return await _personRepository.Update(updatedPerson);
        }
    }
}
