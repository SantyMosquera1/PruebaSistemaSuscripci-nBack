using SistemaSuscripcion.Domain.Entities;

namespace SistemaSuscripcion.Application.Interfaces;

public interface ISubscriptionRepository
{
    Task<bool> HasActiveSubscriptionAsync(Guid userId);
    Task AddAsync(Subscription subscription);
    Task SaveChangesAsync();
}