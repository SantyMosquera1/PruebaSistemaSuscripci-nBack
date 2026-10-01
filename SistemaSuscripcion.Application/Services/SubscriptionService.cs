using SistemaSuscripcion.Application.DTOs;
using SistemaSuscripcion.Application.Interfaces;
using SistemaSuscripcion.Domain.Entities;

namespace SistemaSuscripcion.Application.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _repository;

    // Inyectamos la abstracción del Repositorio, NO el DbContext
    public SubscriptionService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto dto)
    {
        // 1. Validar regla de negocio: ¿Tiene suscripción activa?
        var hasActive = await _repository.HasActiveSubscriptionAsync(dto.UserId);
        if (hasActive)
        {
            throw new InvalidOperationException("El usuario ya cuenta con una suscripción activa.");
        }

        // 2. Crear entidad de Dominio
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            UserId = dto.UserId,
            PlanId = dto.PlanId,
            StartDate = DateTime.UtcNow,
            IsActive = true
        };

        // 3. Guardar cambios en base de datos mediante el repositorio
        await _repository.AddAsync(subscription);
        await _repository.SaveChangesAsync();

        // 4. Retornar DTO de respuesta
        return new SubscriptionDto
        {
            Id = subscription.Id,
            UserId = subscription.UserId,
            PlanId = subscription.PlanId,
            StartDate = subscription.StartDate,
            IsActive = subscription.IsActive
        };
    }
}