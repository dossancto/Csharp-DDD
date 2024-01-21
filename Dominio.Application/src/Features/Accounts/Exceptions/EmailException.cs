namespace Dominio.Application.Features.Accounts.Exceptions;

public class EmailException : Exception
{
    public EmailException(string message) : base(message) { }
}

