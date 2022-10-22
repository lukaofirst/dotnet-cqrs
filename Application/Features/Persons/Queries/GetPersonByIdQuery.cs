using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
        public GetPersonByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
