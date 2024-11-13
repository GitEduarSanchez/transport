using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Dto;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Query;

namespace Poliedro.Billing.Api.Controllers.v1.ControlViaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ControlViajeOrigenController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ControlViajeOrigenDto>> GetAll()
        {
            return await mediator.Send(new GetAllControlViajeOrigenQuery());
        }

        [HttpGet("{id}")]
        public async Task<ControlViajeOrigenDto> GetAsync([FromRoute] int id)
        {
            var getControlViajeOrigenByIdQuery = new GetByIdControlViajeOrigenQuery(id);
            return await mediator.Send(getControlViajeOrigenByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateControlViajeOrigenCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateControlViaje(int id, [FromBody] UpdateControlViajeOrigenCommand command)
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
            var result = await mediator.Send(new DeleteControlViajeOrigenCommand(id));
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
