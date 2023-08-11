using CashFlow.Application.Base.Handlers;
using CashFlow.Application.Base.Models;
using CashFlow.Application.Features.Entries;
using CashFlow.Application.Features.Entries.Commands;
using CashFlow.Application.Features.Entries.Handlers;

namespace CashFlow.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // entries

        services.AddScoped<IHandler<CreateEntry, Response<Entry>>, CreateEntryHandler>();
        services.AddScoped<IHandler<RemoveEntry, Response>, RemoveEntryHandler>();

        return services;
    }
}
