namespace EventManager.WebApi.Entities;

public class EventRegistration
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public Company Company { get; set; }
    
    public Event Event { get; set; }
}