namespace CashFlow.Application.Base.Handlers;

public interface IHandler<TCommand, TResponse>
    where TCommand : class
    where TResponse : class
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
}