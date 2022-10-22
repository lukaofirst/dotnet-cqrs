using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
