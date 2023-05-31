namespace EventManager.WebApi.DtoModels;

public class EventDto : EventShortDto
{
    public string Description { get; set; }

    public string? Image { get; set; }
}