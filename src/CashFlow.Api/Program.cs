using System.Text.Json.Serialization;

using CashFlow.Domain.Base.Persistence;
using CashFlow.Domain.Features.Entries.Commands;
using CashFlow.Domain.Features.Entries.Repositories;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Persistence;
using CashFlow.Infrastructure.Repositories;

using MediatR;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateEntry));

builder.Services.AddDbContext<CashFlowContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServer"), builder =>
    {
        builder.MigrationsAssembly("CashFlow.Infrastructure");
    }));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEntryRepository, EntryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
