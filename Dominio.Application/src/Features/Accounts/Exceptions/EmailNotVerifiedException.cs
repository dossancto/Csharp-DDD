namespace Dominio.Application.Features.Accounts.Exceptions;

public class EmailNotVerifiedException : EmailException
{
    private static string DefaultMessage(string email)
      => $"Email \"{email}\" is not verified";

    public EmailNotVerifiedException(string email) : base(DefaultMessage(email)) { }
}
