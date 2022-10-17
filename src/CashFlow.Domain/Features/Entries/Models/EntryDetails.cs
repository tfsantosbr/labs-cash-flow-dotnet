using CashFlow.Domain.Features.Entries.Enums;

namespace CashFlow.Domain.Features.Entries.Models;

public class EntryDetails
{
    public Guid Id { get; set; }
    public EntryType Type { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
}
