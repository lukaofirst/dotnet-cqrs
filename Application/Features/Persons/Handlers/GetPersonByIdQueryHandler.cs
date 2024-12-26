using Application.DTOs;
using Application.Exceptions;
using Application.Features.Persons.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Persons.Handlers
{
	public class GetPersonByIdQueryHandler(
		IPersonRepository personRepository,
		IMapper mapper)
		: IRequestHandler<GetPersonByIdQuery, PersonDTO>
	{
		public async Task<PersonDTO> Handle(GetPersonByIdQuery command, CancellationToken cancellationToken)
		{
			var id = command.Id;

			var result = await personRepository.GetById(id) ??
				throw new EntityNotFoundException($"Entity with id: [{id}] wasn't found");

			return mapper.Map<PersonDTO>(result);
		}
	}
}
