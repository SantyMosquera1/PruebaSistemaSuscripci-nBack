namespace SistemaSuscripcion.Domain.Entities;

public class Subscription
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }

    // Si la entidad original tenía la relación con User:
    public User? User { get; set; }
}