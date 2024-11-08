using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Conductor.Dto;
using Poliedro.Billing.Application.Conductor.Query;
using Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;
using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VehiculoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ConductorDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ConductorDto> GetAsync([FromRoute] int id)
        {
            var getConductorByIdQuery = new GetByIdConductorQuery(id);
            return await mediator.Send(getConductorByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateConductorCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateConductorCommand command)
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
