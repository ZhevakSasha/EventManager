using AutoMapper;
using EventManager.WebApi.DtoModels;
using EventManager.WebApi.Entities;

namespace EventManager.WebApi;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Event, EventDto>().ReverseMap();
    }
}