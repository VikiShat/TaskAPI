using Microsoft.EntityFrameworkCore;
using TaskAPI.App.ErrorLogs;
using TaskAPI.App.PersonRelationships;
using TaskAPI.App.PhoneNumbers;
using TaskAPI.App.PhysicalPersons; 

namespace TaskAPI.Persistent.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<PersonRelationship> PersonRelationships { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}