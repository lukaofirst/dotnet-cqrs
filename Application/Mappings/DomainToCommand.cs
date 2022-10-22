using Application.Features.Persons.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToCommand : Profile
    {
        public DomainToCommand()
        {
            CreateMap<Person, PersonInsertCommand>().ReverseMap();
            CreateMap<Person, PersonUpdateCommand>().ReverseMap();
        }
    }
}
