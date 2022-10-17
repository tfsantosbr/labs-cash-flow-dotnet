using CashFlow.Domain.Features.Entries.Models;

namespace CashFlow.Domain.Features.Entries.Repositories;

public interface IEntryRepository
{
    Task Add(Entry entry);
    void Remove(Entry entry);
    Task<Entry> GetById(Guid entryId);
    Task<bool> AnyEntry(Guid entryId);
    Task<IEnumerable<EntryItem>> Find(EntryParameters parameters);
    Task<decimal> GetBalance(EntryParameters parameters);
}
