using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.WebApi.DtoModels;
using EventManager.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public IEventService _eventService;
        
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        // GET: api/Event
        [HttpGet]
        public Task<ICollection<EventDto>> Get(CancellationToken cancellationToken)
        {
            return _eventService.GetAll(cancellationToken);
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
