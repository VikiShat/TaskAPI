using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskAPI.App.ErrorLogs.Configurations;

public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
    public void Configure(EntityTypeBuilder<ErrorLog> builder)
    {
        builder.HasKey(e => e.Id);
 
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
 
        builder.Property(e => e.ErrorMessage)
            .IsRequired()
            .HasMaxLength(2000);  
 
        builder.Property(e => e.StackTrace)
            .IsRequired()
            .HasMaxLength(4000); 
 
        builder.Property(e => e.DateOccurred)
            .IsRequired();
 
        builder.Property(e => e.Path)
            .HasMaxLength(500); 
 
        builder.Property(e => e.QueryString)
            .HasMaxLength(1000);  
 
        builder.Property(e => e.Method)
            .IsRequired()
            .HasMaxLength(10); 
    }
}