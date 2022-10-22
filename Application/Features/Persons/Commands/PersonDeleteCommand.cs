using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Commands
{
    public class PersonDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public PersonDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
