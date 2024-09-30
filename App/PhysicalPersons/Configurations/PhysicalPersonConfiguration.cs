using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskAPI.App.PhysicalPersons.Configurations;

public class PhysicalPersonConfiguration : IEntityTypeConfiguration<PhysicalPerson>
{
    public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(pr => pr.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.FirstName)
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .HasMaxLength(50);

         
        builder.Property(p => p.Gender)
            .IsRequired();

        builder.Property(p => p.PersonalNumber)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength()
            .HasColumnType("char(11)");
 
        builder.Property(p => p.DateOfBirth)
            .IsRequired();
 
        builder.HasMany(p => p.PhoneNumbers)
            .WithOne()
            .HasForeignKey(pn => pn.PersonId)
            .OnDelete(DeleteBehavior.Cascade);   
    }
    
}