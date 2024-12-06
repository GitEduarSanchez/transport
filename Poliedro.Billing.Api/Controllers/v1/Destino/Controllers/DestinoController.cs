using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Destino.Commands;
using Poliedro.Billing.Application.Destino.Commands.Validator;
using Poliedro.Billing.Application.Destino.Dto;
using Poliedro.Billing.Application.Destino.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace Poliedro.Billing.Api.Controllers.v1.Destino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DestinoController(IMediator mediator) : ControllerBase
    {

        [SwaggerOperation(Summary = "Retrieve all destinations", Description = "Fetches all available destinations.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operation was successful.", typeof(IEnumerable<DestinoDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Missing or invalid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.", typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IEnumerable<DestinoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [SwaggerOperation(Summary = "Retrieve a destination by ID", Description = "Fetches details of a specific destination using its unique ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Destination retrieved successfully.", typeof(DestinoDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Destination not found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.", typeof(ProblemDetails))]
        [HttpGet("{id}")]
        public async Task<DestinoDto> GetAsync([FromRoute] int id)
        {
            var getDestinoByIdQuery = new GetByIdDestinoQuery(id);
            return await mediator.Send(getDestinoByIdQuery);
        }

        [SwaggerOperation(Summary = "Create a new destination", Description = "Adds a new destination to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Destination created successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation errors occurred.", typeof(IEnumerable<string>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.", typeof(ProblemDetails))]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateDestinoCommand command)
        {
            var validationResult = await new CreateDestinoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [SwaggerOperation(Summary = "Update a destination", Description = "Updates the details of an existing destination.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Destination updated successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request or ID mismatch.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.", typeof(ProblemDetails))]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateDestino(int id, [FromBody] UpdateDestinoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await mediator.Send(command);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a destination", Description = "Removes a destination by its unique ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Destination deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Destination not found.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.", typeof(ProblemDetails))]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteDestinoCommand(id));
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
