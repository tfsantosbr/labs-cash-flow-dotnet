using CashFlow.Domain.Base.Persistence;
using CashFlow.Domain.Features.Entries.Commands;
using CashFlow.Domain.Features.Entries.Repositories;

using MediatR;

namespace CashFlow.Domain.Features.Entries.Handlers;

public class CreateEntryHandler : IRequestHandler<CreateEntry, Entry>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Entry> Handle(CreateEntry request, CancellationToken cancellationToken)
    {
        var entry = new Entry(
            type: request.Type,
            date: request.Date,
            value: request.Value
        );

        await _entryRepository.Add(entry);

        await _unitOfWork.Commit();

        return entry;
    }
}
