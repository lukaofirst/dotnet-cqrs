using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _personService.GetAll();

            return Ok(new SuccessResponse((int)HttpStatusCode.OK, result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _personService.GetById(id);

                return Ok(new SuccessResponse((int)HttpStatusCode.OK, result));
            }
            catch (Exception ex)
            {
                return NotFound(
                    new ErrorResponse(
                        ex.Message, (int)HttpStatusCode.NotFound, ex.StackTrace!
                        )
                    );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonDTO personDTO)
        {
            try
            {
                await _personService.Insert(personDTO);

                return Ok(
                    new SuccessResponse(
                        (int)HttpStatusCode.OK, "Person was created successfully!")
                    );
            }
            catch (Exception ex)
            {
                return Conflict(
                    new ErrorResponse(
                        ex.Message, (int)HttpStatusCode.Conflict, ex.StackTrace!
                        )
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonDTO personDTO)
        {
            try
            {
                await _personService.Update(personDTO);

                return Ok(
                   new SuccessResponse(
                       (int)HttpStatusCode.OK, "Person was updated successfully!")
                   );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse(
                        ex.Message, (int)HttpStatusCode.BadRequest, ex.StackTrace!
                        )
                    );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personService.Delete(id);

                return Ok(
                   new SuccessResponse(
                       (int)HttpStatusCode.OK, "Person was deleted successfully!")
                   );
            }
            catch (Exception ex)
            {
                return NotFound(
                    new ErrorResponse(
                        ex.Message, (int)HttpStatusCode.NotFound, ex.StackTrace!
                        )
                    );
            }
        }
    }
}
