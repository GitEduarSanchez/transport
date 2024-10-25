using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Conductor.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CiudadController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CiudadDto>> GetAll()
        {
            return (IEnumerable<CiudadDto>)await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<CiudadDto> GetAsync([FromRoute] int id)
        {
            var getCiudadByIdQuery = new GetByIdCiudadQuery(id);
            return await mediator.Send(getCiudadByIdQuery);
        }

        

        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateCiudadCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]

        
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

    public class CiudadDto
    {
    }

    internal class GetByIdCiudadQuery : IRequest<CiudadDto>
    {
        private int id;

        public GetByIdCiudadQuery(int id)
        {
            this.id = id;
        }
    }

    public class CreateCiudadCommand
    {
    }
}
