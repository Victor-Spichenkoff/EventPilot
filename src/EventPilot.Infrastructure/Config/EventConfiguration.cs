using EventPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EventPilot.Infrastructure.Config;

public class EventConfiguration: IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder
            .Property(e => e.Description)
            .HasMaxLength(250);
        
        builder
            .Property(e => e.Status)
            .HasConversion<int>();

        builder
            .Property(e => e.CreationDate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
    }
}