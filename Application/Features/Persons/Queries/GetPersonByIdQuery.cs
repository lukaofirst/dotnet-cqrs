using Application.DTOs;
using MediatR;

namespace Application.Features.Persons.Queries;

public class GetPersonByIdQuery(int id) : IRequest<PersonDTO>
{
	public int Id { get; set; } = id;
}
