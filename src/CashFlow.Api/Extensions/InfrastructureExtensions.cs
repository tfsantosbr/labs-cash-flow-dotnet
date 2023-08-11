using CashFlow.Application.Base.Persistence;
using CashFlow.Application.Features.Entries.Repositories;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Persistence;
using CashFlow.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // contexts

        services.AddDbContext<CashFlowContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"), builder =>
            builder.MigrationsAssembly("CashFlow.Infrastructure")));

        // persistence

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // repositories

        services.AddTransient<IEntryRepository, EntryRepository>();

        return services;
    }

    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CashFlowContext>();
        context.Database.Migrate();
    }
}
