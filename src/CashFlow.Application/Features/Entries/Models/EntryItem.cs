using CashFlow.Application.Features.Entries.Enums;

namespace CashFlow.Application.Features.Entries.Models;

public class EntryItem
{
    public Guid Id { get; set; }
    public EntryType Type { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
}
