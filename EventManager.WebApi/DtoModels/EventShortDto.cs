namespace EventManager.WebApi.DtoModels;

public class EventShortDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public DateTime StartAt { get; set; }
    
    public bool Active { get; set; }
}