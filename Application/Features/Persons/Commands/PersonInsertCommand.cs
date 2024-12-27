using Application.DTOs;

namespace Application.Features.Persons.Commands;

public class PersonInsertCommand(PersonDTO request)
	: BasePersonCommand(request)
{
}
