using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Trailer.Commands;
using Poliedro.Billing.Application.Trailer.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Trailer.Commands.Query;
using Poliedro.Billing.Application.Trailer.Dto;

namespace Poliedro.Billing.Api.Controllers.v1.Trailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TrailerController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TrailerDto>> GetAll()
        {
            return await mediator.Send(new GetAllTrailerQuery());
        }

        [HttpGet("{id}")]
        public async Task<TrailerDto> GetAsync([FromRoute] int id)
        {
            var getTrailerByIdQuery = new GetByIdTrailerQuery(id);
            return await mediator.Send(getTrailerByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateTrailerCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrailer(int id, [FromBody] UpdateTrailerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteTrailerCommand(id));
            return Ok(result);
        }

        private IActionResult HandleValidationErrors(List<ValidationFailure> errors)
        {
            GetErrorValidator(errors);
            return BadRequest(errors);
        }

        private static void GetErrorValidator(List<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            {
                Console.WriteLine($"log: {failure.ErrorMessage}");
            }
        }
    }


}
