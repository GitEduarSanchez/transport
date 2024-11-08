using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.departamento.Dto;
using Poliedro.Billing.Application.departamento.Query;
using Poliedro.Billing.Application.departamento.Commands;

namespace Poliedro.Billing.Api.Controllers.v1.departamento
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class departamentoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<departamentoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<departamentoDto> GetAsync([FromRoute] int id)
        {
            var getdepartamentoByIdQuery = new GetByIddepartamentoQuery(id);
            return await mediator.Send(getdepartamentoByIdQuery);
        }



        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreatedepartamentoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreatedepartamentoCommand command)
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
