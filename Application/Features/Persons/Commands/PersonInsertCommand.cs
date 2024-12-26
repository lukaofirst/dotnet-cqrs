using Application.DTOs;

namespace Application.Features.Persons.Commands
{
	public class PersonInsertCommand(PersonDTO request)
		: PersonCommand(request)
	{
	}
}
