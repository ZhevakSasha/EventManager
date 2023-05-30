namespace EventManager.WebApi.Entities;

public class Company
{
    public Guid Id { get; set; }
    
    public string CompanyName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public User User { get; set; }
    public ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
}