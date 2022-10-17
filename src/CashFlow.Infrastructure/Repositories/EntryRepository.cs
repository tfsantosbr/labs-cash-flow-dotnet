using CashFlow.Domain.Features.Entries;
using CashFlow.Domain.Features.Entries.Models;
using CashFlow.Domain.Features.Entries.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories;

public class EntryRepository : IEntryRepository
{
    private readonly DbSet<Entry> _entries;

    public EntryRepository(CashFlowContext context) =>
        _entries = context.Entries;

    public async Task Add(Entry entry) =>
        await _entries.AddAsync(entry);

    public async Task<bool> AnyEntry(Guid entryId) =>
        await _entries.AnyAsync(e => e.Id == entryId);

    public async Task<IEnumerable<EntryItem>> Find(EntryParameters parameters)
    {
        var query = _entries.AsNoTracking();

        query = Filter(parameters, query);

        var items = await query
            .Select(e => new EntryItem
            {
                Id = e.Id,
                Type = e.Type,
                Date = e.Date,
                Value = e.Value,
            })
            .ToListAsync();

        return items;
    }

    public async Task<decimal> GetBalance(EntryParameters parameters)
    {
        var query = _entries.AsNoTracking();

        query = Filter(parameters, query);

        return await query.SumAsync(e => e.Value);
    }

    public async Task<Entry> GetById(Guid entryId) =>
        await _entries.FirstAsync(e => e.Id == entryId);

    public void Remove(Entry entry) =>
        _entries.Remove(entry);

    // Private Methods

    private static IQueryable<Entry> Filter(EntryParameters parameters, IQueryable<Entry> query)
    {
        var startDate = new DateTime(parameters.Date.Year, parameters.Date.Month, parameters.Date.Day);
        var endDate = startDate.AddDays(1).AddMilliseconds(-1);

        query = query.Where(e =>
                    e.Date >= startDate &&
                    e.Date <= endDate);

        return query;
    }
}
