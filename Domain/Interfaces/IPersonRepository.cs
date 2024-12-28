using Domain.Entities;

namespace Domain.Interfaces;

public interface IPersonRepository
{
	Task<List<Person>> GetAll();
	Task<Person?> GetById(int id);
	Task<Person?> GetByName(string? name);
	Task<bool> Insert(Person person);
	Task<bool> Update(Person person, Person updatedPerson);
	Task<bool> Delete(int id);
}
