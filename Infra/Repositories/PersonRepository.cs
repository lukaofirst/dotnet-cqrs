using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAll()
        {
            var persons = await _context.Persons!.AsNoTracking().ToListAsync();

            return persons;
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _context.Persons!.Where(x => x.Id == id).SingleOrDefaultAsync();

            return person!;
        }

        public async Task<Person?> Insert(Person person)
        {
            var entityExist = await EntityAlreadyExist(person.Id, person.Name!);

            if(entityExist)
            {
                return null;
            } else
            {
                await _context.Persons!.AddAsync(person);
                await SaveChangesAsync();

                return person;
            }
        }

        public async Task<Person?> Update(Person person)
        {
            var entityExist = await EntityAlreadyExist(person.Id);

            if(entityExist)
            {
                _context.ChangeTracker.Clear();
                _context.Persons!.Update(person);
                await SaveChangesAsync();

                return person;
            } else
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entityExist = await EntityAlreadyExist(id);

            if (entityExist)
            {
                var personToDelete = await _context.Persons!.SingleAsync(x => x.Id == id);
                _context.Persons!.Remove(personToDelete);

                await SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private async Task<bool> EntityAlreadyExist(int id, string name = "")
        {
            var entityAlreadyExist = await _context.Persons!
                .AsNoTracking()
                .AnyAsync(x => x.Id == id || x.Name == name);

            return entityAlreadyExist;
        }
    }
}
