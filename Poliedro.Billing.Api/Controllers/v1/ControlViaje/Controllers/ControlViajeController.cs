using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.ControlViaje.Query;
using Poliedro.Billing.Application.ControlViaje.Dto;
using Poliedro.Billing.Application.ControlViaje.Commands;

namespace Poliedro.Billing.Api.Controllers.v1.ControlViaje.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ControlViajeController(IMediator mediator) : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<ControlViajeDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }



        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateControlViajeCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> UpdateControlViaje(int id, [FromBody] UpdateControlViajeCommand command)
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
            var result = await mediator.Send(new DeleteControlViajeCommand(id));
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
