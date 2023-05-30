using Microsoft.AspNetCore.Identity;

namespace EventManager.WebApi.Entities;

public class User : IdentityUser
{
    public Guid? CompanyId { get; set; }
    
    public Company Company { get; set; }
    
}