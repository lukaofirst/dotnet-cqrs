using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
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

		public async Task<Person?> Insert(Person person)
		{
			var entityExist = await EntityExist(person.Id, person.Name!);

			if (entityExist)
			{
				return null;
			}
			else
			{
				await context.Persons!.AddAsync(person);
				await context.SaveChangesAsync();

				return person;
			}
		}

		public async Task<Person?> Update(Person person)
		{
			var entityExist = await EntityExist(person.Id);

			if (entityExist)
			{
				context.Persons!.Update(person);
				await context.SaveChangesAsync();

				return person;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> Delete(int id)
		{
			var entityExist = await EntityExist(id);

			if (entityExist)
			{
				var personToDelete = await context.Persons!
					.FirstAsync(x => x.Id == id);

				context.Persons!.Remove(personToDelete);

				var result = await context.SaveChangesAsync();

				return result > 0;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> EntityExist(int id, string name = "")
		{
			var result = await context.Persons!
				.AnyAsync(x => x.Id == id || x.Name == name);

			return result;
		}
	}
}
