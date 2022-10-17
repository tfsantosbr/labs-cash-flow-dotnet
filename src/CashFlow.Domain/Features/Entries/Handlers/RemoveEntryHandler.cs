using CashFlow.Domain.Base.Persistence;
using CashFlow.Domain.Features.Entries.Commands;
using CashFlow.Domain.Features.Entries.Repositories;

using MediatR;

namespace CashFlow.Domain.Features.Entries.Handlers;

public class RemoveEntryHandler : IRequestHandler<RemoveEntry>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveEntry request, CancellationToken cancellationToken)
    {
        var entry = await _entryRepository.GetById(request.EntryId);

        _entryRepository.Remove(entry);

        await _unitOfWork.Commit();

        return Unit.Value;
    }
}
