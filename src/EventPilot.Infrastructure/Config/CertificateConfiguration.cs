using EventPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPilot.Infrastructure.Config;

public class CertificateConfiguration: IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder
            .HasKey(c => new { c.SessionId, RegistrationId = c.EventRegistrationId });
        
        builder
            .HasOne(c => c.Session)
            .WithMany(s => s.Certificates)
            .HasForeignKey(c => c.SessionId);
        
        builder 
            .HasOne(c => c.EventRegistration)
            .WithMany(r => r.Certificates)
            .HasForeignKey(c => c.EventRegistrationId);
        
        
        builder
            .Property(c => c.GenerationDate)
            .HasDefaultValueSql("datetime('now')")
            .ValueGeneratedOnAdd();
    }
}