using MediatR;
using Poliedro.Billing.Application.ControlViajeProducto.Dto;

namespace Poliedro.Billing.Application.ControlViajeProducto.Query;

public record GetByIdControlViajeProductoQuery(int idControlViajeProducto): IRequest<ControlViajeProductoDto>;

