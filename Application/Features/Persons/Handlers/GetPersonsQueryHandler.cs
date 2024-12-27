using Application.Features.Persons.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers;

public class GetPersonsQueryHandler(
	IPersonRepository personRepository,
	IMapper mapper)
	: IRequestHandler<GetPersonsQuery, List<Person>>
{
	public async Task<List<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
	{
		var result = await personRepository.GetAll();

		return mapper.Map<List<Person>>(result);
	}
}
