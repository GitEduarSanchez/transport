using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.departamento.Commands;
using Poliedro.Billing.Application.departamento.Commands.Validator;
using Poliedro.Billing.Application.departamento.Dto;
using Poliedro.Billing.Application.departamento.Query;

namespace Poliedro.Billing.Api.Controllers.v1.departamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class departamentoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<departamentoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<departamentoDto> GetAsync([FromRoute] int id)
        {
            var getdepartamentoByIdQuery = new GetByIddepartamentoQuery(id);
            return await mediator.Send(getdepartamentoByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreatedepartamentoCommand command)
        {
             var validationResult = await new CreatedepartamentoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatedepartamento(int id, [FromBody] UpdatedepartamentoCommand command)
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
            var result = await mediator.Send(new DeletedepartamentoCommand(id));
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
