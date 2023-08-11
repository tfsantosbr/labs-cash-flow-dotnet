using System.Reflection;

using CashFlow.Application.Features.Entries;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure;

public class CashFlowContext : DbContext
{
    public CashFlowContext(DbContextOptions<CashFlowContext> options) : base(options)
    {
    }

    public DbSet<Entry> Entries => Set<Entry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
