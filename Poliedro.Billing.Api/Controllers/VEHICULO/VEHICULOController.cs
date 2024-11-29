using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Vehiculo.Commands;
using Poliedro.Billing.Application.Vehiculo.Dto;
using Poliedro.Billing.Application.Vehiculo.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Vehiculo
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VehiculoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<VehiculoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<VehiculoDto> GetAsync([FromRoute] int id)
        {
            var getVehiculoByIdQuery = new GetByIdVehiculoQuery(id);
            return await mediator.Send(getVehiculoByIdQuery);
        }


        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateVehiculoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateVehiculoCommand command)
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
