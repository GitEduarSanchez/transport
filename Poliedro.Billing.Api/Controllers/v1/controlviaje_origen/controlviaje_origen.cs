using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.controlviaje_origen.Commands;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Dto;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Query;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Validator;

namespace Poliedro.Billing.Api.Controllers.v1.controlviaje_origen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class controlviaje_origenController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<controlviaje_origenDto>> GetAll()
        {
            return await mediator.Send(new GetAllcontrolviaje_origenQuery());
        }

        [HttpGet("{id}")]
        public async Task<controlviaje_origenDto> GetAsync([FromRoute] int id)
        {
            var getcontrolviaje_origenByIdQuery = new GetByIdcontrolviaje_origenQuery(id);
            return await mediator.Send(getcontrolviaje_origenByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] Createcontrolviaje_origenCommand command)
        {
             var validationResult = await new Createcontrolviaje_origenCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateControlViaje(int id, [FromBody] Updatecontrolviaje_origenCommand command)
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
            var result = await mediator.Send(new Deletecontrolviaje_origenCommand(id));
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
