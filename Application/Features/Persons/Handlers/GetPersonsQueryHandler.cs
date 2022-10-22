using Application.Features.Persons.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetAll();
        }
    }
}
