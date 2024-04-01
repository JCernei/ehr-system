using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<LabResult> LabResults { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<LabResult>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Consultation>()
            .Property(e => e.TimeStamp);
        modelBuilder.Entity<LabResult>()
            .Property(e => e.TimeStamp);

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}
