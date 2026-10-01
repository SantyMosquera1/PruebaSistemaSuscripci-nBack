using Microsoft.AspNetCore.Mvc;
using SistemaSuscripcion.Application.DTOs;
using SistemaSuscripcion.Application.Interfaces;

namespace SistemaSuscripcion.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuscripcionesController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SuscripcionesController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionDto dto)
    {
        var result = await _subscriptionService.CreateAsync(dto);
        return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }
}