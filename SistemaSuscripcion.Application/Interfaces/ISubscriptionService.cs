using SistemaSuscripcion.Application.DTOs;

namespace SistemaSuscripcion.Application.Interfaces;

public interface ISubscriptionService
{
    Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto dto);
}