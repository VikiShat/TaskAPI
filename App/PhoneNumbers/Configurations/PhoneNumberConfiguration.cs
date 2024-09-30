using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.App.PhysicalPersons;

namespace TaskAPI.App.PhoneNumbers.Configurations;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    { 
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();   
        builder.Property(p => p.PersonId)
            .IsRequired();   
        builder.Property(p => p.Type)
            .IsRequired();  
        builder.Property(p => p.Number)
            .IsRequired()
            .HasMaxLength(50) ;   
 
        builder.HasOne<PhysicalPerson>()
            .WithMany()
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.Cascade);   
    }
}