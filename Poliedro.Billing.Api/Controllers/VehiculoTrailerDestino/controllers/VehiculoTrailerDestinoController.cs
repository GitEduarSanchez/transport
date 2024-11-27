using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Dto;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Query;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Commands.CreateServerCommand;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VehiculoTrailerDestinoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<VehiculoTrailerDestinoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<VehiculoTrailerDestinoDto> GetAsync([FromRoute] int id)
        {
            var getVehiculoTrailerDestinoByIdQuery = new GetByIdVehiculoTrailerDestinoQuery(id);
            return await mediator.Send(getVehiculoTrailerDestinoByIdQuery);
        }

        

        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateVehiculoTrailerDestinoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateVehiculoTrailerDestinoCommand command)
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
