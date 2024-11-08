using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
<<<<<<<< HEAD:.merge_file_OA3MvM
using Poliedro.Billing.Application.Destino.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Destino.Dto;
using Poliedro.Billing.Application.Destino.Query;
========
using Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Conductor.Dto;
using Poliedro.Billing.Application.Conductor.Query;
using Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;
>>>>>>>> 09faaf4fdbd28f78fc7ed678e4cca8246daca3af:Poliedro.Billing.Api/Controllers/v1/Vehiculo/VehiculoController.cs
using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DestinoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<DestinoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

        [HttpGet("{id}")]
        public async Task<DestinoDto> GetAsync([FromRoute] int id)
        {
            var getDestinoByIdQuery = new GetByIdDestinoQuery(id);
            return await mediator.Send(getDestinoByIdQuery);
        }


        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateDestinoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateDestinoCommand command)
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
