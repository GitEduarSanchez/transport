using MediatR;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Dto;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Query;

public record GetByIdcontrolviaje_origenQuery(int Idcontrolviaje_origen) : IRequest<controlviaje_origenDto>;

