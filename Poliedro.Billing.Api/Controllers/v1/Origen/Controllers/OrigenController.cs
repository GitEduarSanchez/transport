using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Origen.Commands;
using Poliedro.Billing.Application.Origen.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Origen.Commands.Validator;
using Poliedro.Billing.Application.Origen.Dto;
using Poliedro.Billing.Application.Origen.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace Poliedro.Billing.Api.Controllers.v1.Origen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class OrigenController(IMediator mediator) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get State All")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(IEnumerable<OrigenDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
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
