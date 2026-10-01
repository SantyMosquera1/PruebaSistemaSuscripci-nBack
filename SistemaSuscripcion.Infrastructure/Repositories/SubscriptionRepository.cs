using Microsoft.EntityFrameworkCore;
using SistemaSuscripcion.Application.Interfaces;
using SistemaSuscripcion.Domain.Entities;
using SistemaSuscripcion.Infrastructure.Persistence;

namespace SistemaSuscripcion.Infrastructure.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationDbContext _context;

    public SubscriptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasActiveSubscriptionAsync(Guid userId)
    {
        return await _context.Subscriptions
            .AnyAsync(s => s.UserId == userId && s.IsActive);
    }

    public async Task AddAsync(Subscription subscription)
    {
        await _context.Subscriptions.AddAsync(subscription);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}