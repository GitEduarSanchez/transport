using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poliedro.Billing.Application.Common.Exeptions;
using Poliedro.Billing.Application.Producto.commands;
using Poliedro.Billing.Application.Producto.Commands;
using Poliedro.Billing.Application.Producto.Dto;
using Poliedro.Billing.Application.Producto.Query;
using Poliedro.Billing.ApplicationProducto.Commands.Validator;

namespace Poliedro.Billing.Api.Controllers.v1.Producto.Controllers
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
                var validationResult = await new CreateProductoCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            await mediator.Send(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] UpdateProductoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteProductoCommand(id));
            return Ok(result);
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
