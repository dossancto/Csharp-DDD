public enum ResultStatus
{
    Success,
    Fail
}

public class ExceptionWrap
{

    public static ExceptionWrapping<T> Wrap<T>(Func<T> func)
    {
        try
        {
            var result = func();
            return (result, null);
        }
        catch (Exception e)
        {
            return (default(T), e);
        }
    }

}

public class ExceptionWrapping<T>
{
    public T? Data { get; }
    public Exception? Error { get; }

    public ResultStatus Status { get; }

    public ExceptionWrapping(T? Data, Exception? Exception)
    {
        this.Data = Data;
        this.Error = Exception;

        if (Data is not null)
        {
            Status = ResultStatus.Success;
        }
        else
        {
            Status = ResultStatus.Fail;
        }
    }

    public static implicit operator ExceptionWrapping<T>((T? data, Exception? e) t) => new(t.data, t.e);

    public bool IsError
    => Status is ResultStatus.Fail;

    public bool IsSuccess
    => Status is ResultStatus.Success;

    public bool TryError(out Exception e)
    {
        if (IsSuccess)
        {
            e = new();
            return false;
        }

        e = Error!;
        return true;
    }

    public bool TrySuccess(out T data)
    {
        if (IsError)
        {
            data = default(T)!;
            return false;
        }

        data = Data!;
        return true;
    }

    public void ThrowException()
    {
        if (IsSuccess) return;

        throw Error!;
    }
}
