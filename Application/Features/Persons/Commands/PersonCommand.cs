using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Commands
{
    public class PersonCommand : IRequest<Person>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
