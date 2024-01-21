namespace Dominio.Application.Features.Accounts.Exceptions;

public class EmailException : AccountException
{
    public EmailException(string message) : base(message) { }
}

