using CashFlow.Application.Base.Handlers;
using CashFlow.Application.Base.Models;
using CashFlow.Application.Base.Persistence;
using CashFlow.Application.Features.Entries.Commands;
using CashFlow.Application.Features.Entries.Repositories;

namespace CashFlow.Application.Features.Entries.Handlers;

public class RemoveEntryHandler : IHandler<RemoveEntry, Response>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(RemoveEntry command, CancellationToken cancellationToken = default)
    {
        var entry = await _entryRepository.GetById(command.EntryId);

        _entryRepository.Remove(entry);

        await _unitOfWork.Commit();

        return Response.Ok();
    }
}
