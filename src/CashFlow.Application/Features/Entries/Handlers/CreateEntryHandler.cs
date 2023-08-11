using CashFlow.Application.Base.Handlers;
using CashFlow.Application.Base.Models;
using CashFlow.Application.Base.Persistence;
using CashFlow.Application.Features.Entries.Commands;
using CashFlow.Application.Features.Entries.Repositories;

namespace CashFlow.Application.Features.Entries.Handlers;

public class CreateEntryHandler : IHandler<CreateEntry, Response<Entry>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Entry>> Handle(CreateEntry command, CancellationToken cancellationToken = default)
    {
        var entry = new Entry(
            type: command.Type,
            date: command.Date,
            value: command.Value
        );

        await _entryRepository.Add(entry);

        await _unitOfWork.Commit();

        return Response<Entry>.Ok(entry);
    }
}
