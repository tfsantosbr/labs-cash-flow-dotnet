namespace CashFlow.Application.Base.Models;

public class Response<T> : Response where T : class
{
    public T? Data { get; set; }

    public static Response<T> Ok(T data)
    {
        return new Response<T>()
        {
            Data = data
        };
    }

    public static new Response<T> Ok()
    {
        return new Response<T>();
    }
}

public class Response
{
    public static Response Ok()
    {
        return new Response();
    }
}
