using Application.Features.Persons.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
    public class PersonDeleteCommandHandler : IRequestHandler<PersonDeleteCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public PersonDeleteCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _personRepository.Delete(request.Id);
        }
    }
}
