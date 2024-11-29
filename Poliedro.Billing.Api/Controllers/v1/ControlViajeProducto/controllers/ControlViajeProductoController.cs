using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.ControlViajeProducto.Commands;
using Poliedro.Billing.Application.ControlViajeProducto.Commands.Validator;
using Poliedro.Billing.Application.ControlViajeProducto.Dto;
using Poliedro.Billing.Application.ControlViajeProducto.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace Poliedro.Billing.Api.Controllers.v1.ControlViajeProducto.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ControlViajeProductoController(IMediator mediator) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get State All")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetAllControlViajeProductoQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        
        [HttpGet]
        public async Task<IEnumerable<ControlViajeProductoDto>> GetAll()
        {
            return await mediator.Send(new GetAllControlViajeProductoQuery());
        }

        [HttpGet("{id}")]
        public async Task<ControlViajeProductoDto> GetAsync([FromRoute] int id)
        {
            var getConductorByIdQuery = new GetByIdControlViajeProductoQuery(id);
            return await mediator.Send(getConductorByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateControlViajeProductoCommand command)
        {
            var validationResult = await new CreateControlViajeProductoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] UpdatecontrolViajeProductoCommand command)
        {
            if (id != command.idControlViajeProducto)
            {
                return BadRequest();
            }

            await mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeletecontrolViajeProductoCommand(id));
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
