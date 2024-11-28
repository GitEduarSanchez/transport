using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.CategoriaDocumento.Dto;
using Poliedro.Billing.Application.CategoriaDocumento.Query;
using Poliedro.Billing.Application.CategoriaDocumento.Commands;

namespace Poliedro.Billing.Api.Controllers.v1.CategoriaDocumento
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CategoriaDocumentoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CategoriaDocumentoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<CategoriaDocumentoDto> GetAsync([FromRoute] int id)
        {
            var getCategoriaDocumentoByIdQuery = new GetByIdCategoriaDocumentoQuery(id);
            return await mediator.Send(getCategoriaDocumentoByIdQuery);
        }



        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] CreateCategoriaDocumentoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateCategoriaDocumentoCommand command)
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
