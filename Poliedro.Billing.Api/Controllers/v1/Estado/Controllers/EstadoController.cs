using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Estado.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Estado.Dto;
using Poliedro.Billing.Application.Estado.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EstadoController(IMediator mediator) : ControllerBase
    {
          [HttpGet]
        public async Task<IEnumerable<EstadoDto>> GetAll()
        {
            return await mediator.Send(new GetAllEstadoQuery());
        }

        [HttpGet("{id}")]
        public async Task<EstadoDto> GetAsync([FromRoute] int id)
        {
            var getEstadoByIdQuery = new GetByIdEstadoQuery(id);
            return await mediator.Send(getEstadoByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateEstadoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateEstadoCommand command)
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
