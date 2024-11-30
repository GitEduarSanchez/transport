using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Estado.Commands;
using Poliedro.Billing.Application.Estado.Commands.Dto;
using Poliedro.Billing.Application.Estado.Commands.Query;
using Poliedro.Billing.Application.Estado.Commands.Validator;
using Swashbuckle.AspNetCore.Annotations;


namespace Poliedro.Billing.Api.Controllers.v1.Estado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EstadoController(IMediator mediator) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get State All")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetAllEstadoQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IEnumerable<EstadoDto>> GetAll()
        {
            return await mediator.Send(new GetAllEstadoQuery());
        }

        [SwaggerOperation(Summary = "Get State ById")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetByIdEstadoQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]

        [HttpGet("{id}")]
        public async Task<EstadoDto> GetAsync([FromRoute] int id)
        {
            var getEstadoByIdQuery = new GetByIdEstadoQuery(id);
            return await mediator.Send(getEstadoByIdQuery);
        }

        [SwaggerOperation(Summary = "Create a new State")]
        [SwaggerResponse(StatusCodes.Status201Created, "The state was created successfully.", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
    
        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateEstadoCommand command)
        {
            var validationResult = await new CreateEstadoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] UpdateEstadoCommand command)
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
            var result = await mediator.Send(new DeleteEstadoCommand(id));
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
