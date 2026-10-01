using Microsoft.EntityFrameworkCore;
using SistemaSuscripcion.Application.Interfaces;
using SistemaSuscripcion.Domain.Entities;

namespace SistemaSuscripcion.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
}