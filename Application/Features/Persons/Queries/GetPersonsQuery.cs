using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Queries
{
    public class GetPersonsQuery : IRequest<List<Person>>
    {
    }
}
