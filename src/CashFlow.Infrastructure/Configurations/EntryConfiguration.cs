using CashFlow.Domain.Features.Entries;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Configurations;

public class EntryConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.ToTable("Entries").HasKey(e => e.Id);
        
        builder.Property(e => e.Value).HasPrecision(10, 2);
    }
}
