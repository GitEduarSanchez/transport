using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Concepto.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Concepto.Dto;
using Poliedro.Billing.Application.Concepto.Query;
using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ConceptoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ConceptoDto>> GetAll()
        {
            return await mediator.Send(new GetAllConceptoQuery());
        }

        [HttpGet("{id}")]
        public async Task<ConceptoDto> GetAsync([FromRoute] int id)
        {
            var getConceptoByIdQuery = new GetByIdConceptoQuery(id);
            return await mediator.Send(getConceptoByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateConceptoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateConceptoCommand command)
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
