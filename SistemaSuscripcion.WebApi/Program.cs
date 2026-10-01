using Microsoft.EntityFrameworkCore;
using SistemaSuscripcion.Application.Interfaces;
using SistemaSuscripcion.Application.Services;
using SistemaSuscripcion.Domain.Entities;
using SistemaSuscripcion.Infrastructure.Persistence;
using SistemaSuscripcion.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar DbContext con Base de Datos en Memoria
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("SuscripcionesDb"));

// 2. Registrar Abstracciones y Servicios (Inyección de Dependencias)
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Sembrar datos de prueba (Seed Data)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Seed de un usuario de prueba con el Guid requerido
    var testUserId = Guid.Parse("d79203a5-108a-493e-a690-642100863004");
    if (!context.Users.Any(u => u.Id == testUserId))
    {
        context.Users.Add(new User
        {
            Id = testUserId,
            Name = "Usuario Prueba",
            Email = "prueba@test.com"
        });
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (InvalidOperationException ex)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new { message = ex.Message });
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new { message = "Ocurrió un error inesperado." });
    }
});

app.Run();