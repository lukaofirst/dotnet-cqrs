using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Person>? Persons { get; set; }
}
