using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.categoria_documento.Dto;
using Poliedro.Billing.Application.categoria_documento.Query;
using Poliedro.Billing.Application.categoria_documento.Commands;

namespace Poliedro.Billing.Api.Controllers.v1.categoria_documento
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class categoria_documentoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<categoria_documentoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<categoria_documentoDto> GetAsync([FromRoute] int id)
        {
            var getCiudadByIdQuery = new GetByIdcategoria_documentoQuery(id);
            return await mediator.Send(getCiudadByIdQuery);
        }



        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] Createcategoria_documentoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Createcategoria_documentoCommand command)
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
