using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;
using Poliedro.Billing.Application.Producto.Dto;
using Poliedro.Billing.Application.Producto.Query;

namespace Poliedro.Billing.Api.Controllers.v1.Server
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProductoController(IMediator mediator) : ControllerBase
    {
       [HttpGet]
        public async Task<IEnumerable<ProductoDto>> GetAll()
        {
            return await mediator.Send(new GetAllActuatorsQuery());
        }

         [HttpGet("{id}")]
        public async Task<ProductoDto> GetAsync([FromRoute] int id)
        {
            var getProductoByIdQuery = new GetByIdProductoQuery(id);
            return await mediator.Send(getProductoByIdQuery);
        }



        [HttpPost]
                
        public async Task<ActionResult<bool>> Create([FromBody] CreateProductoCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateProductoCommand command)
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
