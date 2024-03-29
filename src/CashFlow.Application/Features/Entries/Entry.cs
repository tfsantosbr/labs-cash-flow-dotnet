using CashFlow.Application.Features.Entries.Enums;

namespace CashFlow.Application.Features.Entries;

public class Entry
{
    public Entry(EntryType type, DateTime date, decimal value, Guid? id = null)
    {
        if (value <= 0)
            throw new Exception("Entry value must be positive");

        Id = id ?? Guid.NewGuid();
        Type = type;
        Date = date;
        Value = type == EntryType.Credit ? value : value * -1;
    }

    private Entry()
    {
    }

    public Guid Id { get; private set; }
    public EntryType Type { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Value { get; private set; }
}
