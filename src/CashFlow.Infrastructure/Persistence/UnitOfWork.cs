using CashFlow.Domain.Base.Persistence;

namespace CashFlow.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly CashFlowContext _context;

    public UnitOfWork(CashFlowContext context) =>
        _context = context;

    public async Task Commit() =>
        await _context.SaveChangesAsync();
}
