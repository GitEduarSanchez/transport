using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.unidad_medida.commands;
using Poliedro.Billing.Application.unidad_medida.Commands.Validator;
using Poliedro.Billing.Application.unidad_medida.Dto;
using Poliedro.Billing.Application.unidad_medida.Query;

namespace Poliedro.Billing.Api.Controllers.v1.unidad_medida.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UnidadMedidaController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<unidad_medidaDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<unidad_medidaDto> GetAsync([FromRoute] int id)
        {
            var getunidad_medidaByIdQuery = new GetByIdunidad_medidaQuery(id);
            return await mediator.Send(getunidad_medidaByIdQuery);
        }



        [HttpPost]

        public async Task<ActionResult<bool>> Create([FromBody] Createunidad_medidaCommand command)
        {
              var validationResult = await new Createunidad_medidaCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Createunidad_medidaCommand command)
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
