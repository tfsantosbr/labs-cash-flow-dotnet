namespace CashFlow.Application.Features.Entries.Commands;

public class RemoveEntry
{
    public RemoveEntry(Guid entryId)
    {
        EntryId = entryId;
    }

    public Guid EntryId { get; set; }
}
