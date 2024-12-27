using Application.DTOs;
using Application.Features.Persons.Commands;
using Application.Features.Persons.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(ISender sender) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var result = await sender.Send(new GetPersonsQuery());

		return Ok(new SuccessResponse((int)HttpStatusCode.OK, result));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		try
		{
			var result = await sender.Send(new GetPersonByIdQuery(id));

			return Ok(new SuccessResponse((int)HttpStatusCode.OK, result));
		}
		catch (Exception ex)
		{
			return NotFound(
				new ErrorResponse(
					ex.Message, (int)HttpStatusCode.NotFound)
				);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Post(PersonDTO personDTO)
	{
		try
		{
			await sender.Send(new PersonInsertCommand(personDTO));

			return Ok(
				new SuccessResponse(
					(int)HttpStatusCode.OK, "Person was created successfully!")
				);
		}
		catch (Exception ex)
		{
			return Conflict(
				new ErrorResponse(
					ex.Message, (int)HttpStatusCode.Conflict)
				);
		}
	}

	[HttpPut]
	public async Task<IActionResult> Update(PersonDTO personDTO)
	{
		try
		{
			await sender.Send(new PersonUpdateCommand(personDTO));

			return Ok(
			   new SuccessResponse(
				   (int)HttpStatusCode.OK, "Person was updated successfully!")
			   );
		}
		catch (Exception ex)
		{
			return BadRequest(
				new ErrorResponse(
					ex.Message, (int)HttpStatusCode.BadRequest)
				);
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await sender.Send(new PersonDeleteCommand(id));

			return Ok(
			   new SuccessResponse(
				   (int)HttpStatusCode.OK, "Person was deleted successfully!")
			   );
		}
		catch (Exception ex)
		{
			return NotFound(
				new ErrorResponse(
					ex.Message, (int)HttpStatusCode.NotFound)
				);
		}
	}
}
