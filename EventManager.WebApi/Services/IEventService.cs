using EventManager.WebApi.DtoModels;

namespace EventManager.WebApi.Services;

public interface IEventService
{
    Task<EventDto?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task<ICollection<EventDto>> GetAll(CancellationToken cancellationToken = default);

    Task<ICollection<EventDto>> GetAvailable(CancellationToken cancellationToken = default);

    Task<EventDto> Create(EventDto eventDto, CancellationToken cancellationToken = default);

    Task Update(EventDto eventDto, CancellationToken cancellationToken = default);

    Task Publish(Guid eventId, CancellationToken cancellationToken = default);

    Task UnPublish(Guid eventId, CancellationToken cancellationToken = default);
    
    Task Delete(Guid id, CancellationToken cancellationToken = default);   
}