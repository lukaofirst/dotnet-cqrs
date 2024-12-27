using Application.DTOs;

namespace Application.Features.Persons.Commands;

public class PersonUpdateCommand(PersonDTO request)
	: BasePersonCommand(request)
{
}
