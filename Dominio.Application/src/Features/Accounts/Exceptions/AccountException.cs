namespace Dominio.Application.Features.Accounts.Exceptions;

public class AccountException : Exception
{
    public AccountException(string message) : base(message)
    {
    }
}

