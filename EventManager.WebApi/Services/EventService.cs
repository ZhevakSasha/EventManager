using AutoMapper;
using EventManager.WebApi.DtoModels;
using EventManager.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.WebApi.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public EventService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EventDto?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var @event = await _dbContext.Events
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (@event is not null)
        {
            var eventDto = _mapper.Map<EventDto>(@event);

            return eventDto;
        }

        return null;
    }

    public async Task<ICollection<EventDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var events = await _dbContext.Events
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        var dtoList = _mapper.Map<ICollection<EventDto>>(events);

        return dtoList;
    }

    public async Task<ICollection<EventDto>> GetAvailable(CancellationToken cancellationToken = default)
    {
        var events = await _dbContext.Events
            .Where(x => x.Active)
            .ToListAsync(cancellationToken);

        var dtoList = _mapper.Map<ICollection<EventDto>>(events);

        return dtoList;
    }

    public async Task<EventDto> Create(EventDto eventDto, CancellationToken cancellationToken = default)
    {
        var @event = _mapper.Map<Event>(eventDto);

        await _dbContext.Events.AddAsync(@event, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        eventDto = _mapper.Map<EventDto>(@event);

        return eventDto;
    }

    public async Task Update(EventDto eventDto, CancellationToken cancellationToken = default)
    {
        var @event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventDto.Id, cancellationToken);
        if (@event is null)
        {
            throw new ApplicationException("Event is not found");
        }

        @event.Update(eventDto);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Publish(Guid eventId, CancellationToken cancellationToken = default)
    {
        var @event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventId, cancellationToken);

        if (@event is null)
        {
            throw new ApplicationException("Event is not found");
        }

        @event.Active = true;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UnPublish(Guid eventId, CancellationToken cancellationToken = default)
    {
        var @event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventId, cancellationToken);

        if (@event is null)
        {
            throw new ApplicationException("Event is not found");
        }

        @event.Active = false;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var @event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (@event == null)
        {
            throw new ApplicationException("Event is not found");
        }

        _dbContext.Events.Remove(@event);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}