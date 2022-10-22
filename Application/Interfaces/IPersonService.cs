using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetAll();
        Task<PersonDTO> GetById(int id);
        Task Insert(PersonDTO person);
        Task Update(PersonDTO person);
        Task Delete(int id);
    }
}
