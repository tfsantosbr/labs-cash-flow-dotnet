namespace CashFlow.Domain.Base.Persistence;

public interface IUnitOfWork
{
    Task Commit();
}
