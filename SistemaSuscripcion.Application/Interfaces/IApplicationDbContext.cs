using Microsoft.EntityFrameworkCore;
using SistemaSuscripcion.Domain.Entities;

namespace SistemaSuscripcion.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Subscription> Subscriptions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}