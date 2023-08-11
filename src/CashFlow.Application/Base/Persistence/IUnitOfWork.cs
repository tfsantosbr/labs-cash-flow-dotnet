namespace CashFlow.Application.Base.Persistence;

public interface IUnitOfWork
{
    Task Commit();
}
