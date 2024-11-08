using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.TipoVehiculo.Commands.CreateServerCommand;
using Poliedro.Billing.Application.TipoVehiculo.Dto;
using Poliedro.Billing.Application.TipoVehiculo.Query;

namespace Poliedro.Billing.Api.Controllers.v1.TipoVehiculo
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoVehiculoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TipoVehiculoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<TipoVehiculoDto> GetAsync([FromRoute] int id)
        {
            var getTipoVehiculoByIdQuery = new GetByIdTipoVehiculoQuery(id);
            return await mediator.Send(getTipoVehiculoByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateTipoVehiculoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateTipoVehiculoCommand command)
        {
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
