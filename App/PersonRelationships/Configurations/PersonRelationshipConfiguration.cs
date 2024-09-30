using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.App.PhysicalPersons;

namespace TaskAPI.App.PersonRelationships.Configurations;

public class PersonRelationshipConfiguration : IEntityTypeConfiguration<PersonRelationship>
{
    public void Configure(EntityTypeBuilder<PersonRelationship> builder)
    {
        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Id)
            .ValueGeneratedOnAdd();   
        builder.Property(pr => pr.FirstPersonId)
            .IsRequired(); 
        builder.Property(pr => pr.SecondPersonId)
            .IsRequired();
 
        builder.Property(pr => pr.Type)
            .IsRequired();
 
        builder.HasOne<PhysicalPerson>()
            .WithMany()
            .HasForeignKey(pr => pr.FirstPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PhysicalPerson>()
            .WithMany()
            .HasForeignKey(pr => pr.SecondPersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}