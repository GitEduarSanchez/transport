using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.ControlViaje.Query;
using Poliedro.Billing.Application.ControlViaje.Dto;
using Poliedro.Billing.Application.ControlViaje.Commands;
using Poliedro.Billing.Application.ControlViaje.Commands.Validator;
using Swashbuckle.AspNetCore.Annotations;
using Poliedro.Billing.Application.ControlViaje.Commands.Query;

namespace Poliedro.Billing.Api.Controllers.v1.ControlViaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ControlViajeController(IMediator mediator) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get State All")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetAllControlViajeQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IEnumerable<ControlViajeDto>> GetAll()
        {
            return await mediator.Send(new GetAllControlViajeQuery());
        }

        [SwaggerOperation(Summary = "Get ControlViaje by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(ControlViajeDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The requested resource could not be found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpGet("{id}")]
        public async Task<ControlViajeDto> GetAsync([FromRoute] int id)
        {
            var getControlViajeByIdQuery = new GetByIdControlViajeQuery(id);
            return await mediator.Send(getControlViajeByIdQuery);
        }

        [SwaggerOperation(Summary = "Create a new ControlViaje")]
        [SwaggerResponse(StatusCodes.Status201Created, "The resource was successfully created.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters or validation errors.", typeof(IEnumerable<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateControlViajeCommand command)
        {
            var validationResult = await new CreateControlViajeCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [SwaggerOperation(Summary = "Update an existing ControlViaje")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The resource was successfully updated.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters or validation errors.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
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

        [SwaggerOperation(Summary = "Delete a ControlViaje by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "The resource was successfully deleted.", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The requested resource could not be found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
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
