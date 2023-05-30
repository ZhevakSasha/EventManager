namespace EventManager.WebApi.Entities;

public class Event
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string? Image { get; set; }
    
    public bool Active { get; set; }
    
    public DateTime StartAt { get; set; }
}