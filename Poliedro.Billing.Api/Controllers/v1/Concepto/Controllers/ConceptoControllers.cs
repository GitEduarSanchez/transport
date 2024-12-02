using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Concepto.Commands;
using Poliedro.Billing.Application.Concepto.Commands.Query;
using Poliedro.Billing.Application.Concepto.Commands.Validator;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Application.Concepto.Commands;
using Swashbuckle.AspNetCore.Annotations;


namespace Poliedro.Billing.Api.Controllers.v1.Concepto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ConceptoController(IMediator mediator) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get Concept All")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetAllConceptoQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IEnumerable<ConceptoDto>> GetAll()
        {
            return await mediator.Send(new GetAllConceptoQuery());
        }

        [SwaggerOperation(Summary = "Get by id Concept")]
        [SwaggerResponse(StatusCodes.Status200OK, "The operation was successful.", typeof(GetByIdConceptoQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The specified concept was not found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpGet("{id}")]
        public async Task<ConceptoDto> GetAsync([FromRoute] int id)
        {
            var getConceptoByIdQuery = new GetByIdConceptoQuery(id);
            return await mediator.Send(getConceptoByIdQuery);
        }

        [SwaggerOperation(Summary = "Create new client Concept")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The operation was successful.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateConceptoCommand command)
        {
            var validationResult = await new CreateConceptoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select (e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [SwaggerOperation(Summary = "Update Concept")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The operation was successful.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The specified concept was not found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] UpdateConceptoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await mediator.Send(command);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete Concept")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The operation was successful.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect request parameters.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The request lacks valid authentication credentials.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The specified concept was not found.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error processing the request.", typeof(ProblemDetails))]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteConceptoCommand(id));
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
