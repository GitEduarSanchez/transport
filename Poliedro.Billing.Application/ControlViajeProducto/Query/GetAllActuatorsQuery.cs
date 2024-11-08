using MediatR;
using Poliedro.Billing.Application.ControlViajeProducto.Dto;

namespace Poliedro.Billing.Application.ControlViajeProducto.Query;

public record GetAllControlViajeProductoQuery: IRequest<IEnumerable<ControlViajeProductoDto>>;

