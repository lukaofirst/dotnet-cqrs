using Application.Features.Persons.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetById(request.Id);
        }
    }
}
