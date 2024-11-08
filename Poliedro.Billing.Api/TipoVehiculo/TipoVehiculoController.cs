using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoVehiculoController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateConductorCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpGet("{id}")]
        public async Task<TipoVehiculoDto> GetAsync([FromRoute] int id)
        {
            var getTipoVehiculoByIdQuery = new GetByTipoVehiculoQuery(id);
            return await mediator.Send(getTipoVehiculoByIdQuery);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
