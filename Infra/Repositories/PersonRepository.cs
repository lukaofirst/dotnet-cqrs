using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PersonRepository(DataContext context) : IPersonRepository
{
	public async Task<List<Person>> GetAll()
	{
		var persons = await context.Persons!
			.AsNoTracking()
			.ToListAsync();

		return persons;
	}

	public async Task<Person?> GetById(int id)
	{
		var person = await context.Persons!
			.FirstOrDefaultAsync(x => x.Id == id);

		return person!;
	}

	public async Task<bool> Insert(Person person)
	{
		await context.Persons!.AddAsync(person);
		var result = await context.SaveChangesAsync();

		return result > 0;
	}

	public async Task<bool> Update(Person person, Person updatedPerson)
	{
		person.Name = updatedPerson.Name;
		person.Age = updatedPerson.Age;

		var result = await context.SaveChangesAsync();

		return result > 0;
	}

	public async Task<bool> Delete(int id)
	{
		var person = await context.Persons!
			.FirstOrDefaultAsync(x => x.Id == id);

		if (person is null)
			return false;

		context.Persons!.Remove(person);

		var result = await context.SaveChangesAsync();

		return result > 0;
	}
}
