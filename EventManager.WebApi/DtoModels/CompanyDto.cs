using EventManager.WebApi.Entities;

namespace EventManager.WebApi.DtoModels;

public class CompanyDto
{
    public Guid Id { get; set; }
    
    public string CompanyName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public ICollection<EventRegistration> EventRegistrations { get; set; }
}