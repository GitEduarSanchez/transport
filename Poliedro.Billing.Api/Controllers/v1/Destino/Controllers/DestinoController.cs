using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Destino.Commands;
using Poliedro.Billing.Application.Destino.Commands.Validator;
using Poliedro.Billing.Application.Destino.Dto;
using Poliedro.Billing.Application.Destino.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Destino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DestinoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<DestinoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<DestinoDto> GetAsync([FromRoute] int id)
        {
            var getDestinoByIdQuery = new GetByIdDestinoQuery(id);
            return await mediator.Send(getDestinoByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateDestinoCommand command)
        {
            var validationResult =await new CreateDestinoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
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


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteDestinoCommand(id));
            return Ok (result);
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
