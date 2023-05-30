using EventManager.WebApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManager.WebApi;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Event> Events => Set<Event>();

    public DbSet<Company> Companies => Set<Company>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Event>(b =>
        {
            b.HasKey(x => x.Id);
        });

        builder.Entity<Company>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasMany<EventRegistration>(x => x.EventRegistrations)
                .WithOne(x => x.Company)
                .HasForeignKey(x=> x.Id);

            b.HasIndex(x => x.CompanyName).IsUnique();

            b.Property(x => x.PhoneNumber).HasMaxLength(20);
        });

        builder.Entity<EventRegistration>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasOne(x => x.Event);
        });
        
        builder.Entity<User>(b =>
        {
            b.HasOne(x => x.Company)
                .WithOne(x=> x.User)
                .HasForeignKey<User>(x=> x.CompanyId);
        });

    }
    
}