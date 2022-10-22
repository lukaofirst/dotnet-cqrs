using Application.DTOs;
using Application.Exceptions;
using Application.Features.Persons.Commands;
using Application.Features.Persons.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PersonService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            var personsQuery = new GetPersonsQuery();

            var result = await _mediator.Send(personsQuery);

            return _mapper.Map<List<PersonDTO>>(result);
        }

        public async Task<PersonDTO> GetById(int id)
        {
            var personByIdQuery = new GetPersonByIdQuery(id);

            var result = await _mediator.Send(personByIdQuery);

            if (result == null)
                throw new EntityNotFoundException($"Entity with id: [{id}] wasn't found");

            return _mapper.Map<PersonDTO>(result);
        }

        public async Task Insert(PersonDTO person)
        {
            var mappedEntity = _mapper.Map<Person>(person);
            var personInsertCommand = _mapper.Map<PersonInsertCommand>(mappedEntity);

            var result = await _mediator.Send(personInsertCommand);

            if (result == null)
                throw new EntityAlreadyExistException("Could not insert entity, because it already exist in our database");
        }

        public async Task Update(PersonDTO person)
        {
            var mappedEntity = _mapper.Map<Person>(person);
            var personUpdateCommand = _mapper.Map<PersonUpdateCommand>(mappedEntity);

            var result = await _mediator.Send(personUpdateCommand);

            if (result == null)
                throw new EntityNotFoundException("Could not update entity, because it doesn't exist in our database");
        }

        public async Task Delete(int id)
        {
            var personDeleteCommand = new PersonDeleteCommand(id);

            var result = await _mediator.Send(personDeleteCommand);

            if (!result)
                throw new EntityNotFoundException($"Entity with id: [{id}] wasn't found");
        }
    }
}
