using MediatR;

namespace Application.Features.Persons.Commands;

public class PersonDeleteCommand(int id) : IRequest<bool>
{
	public int Id { get; set; } = id;
}
