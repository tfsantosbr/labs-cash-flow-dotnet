using MediatR;

namespace CashFlow.Domain.Features.Entries.Commands;

public class RemoveEntry : IRequest
{
    public RemoveEntry(Guid entryId)
    {
        EntryId = entryId;
    }

    public Guid EntryId { get; set; }
}
