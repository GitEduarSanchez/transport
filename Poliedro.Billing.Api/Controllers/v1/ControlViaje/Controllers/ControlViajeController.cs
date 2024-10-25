using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.ControlViaje.Query;
using Poliedro.Billing.Application.ControlViaje.Commands.CreateServerCommand;
using Poliedro.Billing.Application.ControlViaje.Dto;


namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ControlViajeController(IMediator mediator) : ControllerBase
    {

        
        [HttpGet]
        public async Task<IEnumerable<ControlViajeDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

       

         [HttpGet("{id}")]
        public async Task<ControlViajeDto> GetAsync([FromRoute] int id)
        {
            var getControlViajeByIdQuery = new GetByIdControlViajeQuery(id);
            return await mediator.Send(getControlViajeByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateControlViajeCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateControlViajeCommand command)
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
