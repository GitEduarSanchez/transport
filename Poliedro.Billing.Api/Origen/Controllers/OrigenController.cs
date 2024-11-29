using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Origen.Commands;
using Poliedro.Billing.Application.Origen.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Origen.Commands.Validator;
using Poliedro.Billing.Application.Origen.Dto;
using Poliedro.Billing.Application.Origen.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class OrigenController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<OrigenDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<OrigenDto> GetAsync([FromRoute] int id)
        {
            var getOrigenByIdQuery = new GetByIdOrigenQuery(id);
            return await mediator.Send(getOrigenByIdQuery);
        }

        

        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateOrigenCommand command)
        {
              var validationResult = await new CreateOrigenCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrigen(int id, [FromBody] UpdateOrigenCommand command)
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
            var result = await mediator.Send(new DeleteOrigenCommand(id));
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
