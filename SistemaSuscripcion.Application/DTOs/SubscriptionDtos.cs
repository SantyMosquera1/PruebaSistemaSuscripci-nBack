namespace SistemaSuscripcion.Application.DTOs;

public class SubscriptionDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }
}

public class CreateSubscriptionDto
{
    public Guid UserId { get; set; }
    public Guid PlanId { get; set; }
}