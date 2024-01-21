using Dominio.Application.Features.Accounts.Exceptions;

namespace Dominio.Application.Features.Accounts.Types;

public class VerifiedEmail
{
    public string Address { get; private set; }

    public static implicit operator VerifiedEmail(string email) => new(CheckVerifiedEmail(email));
    public static implicit operator VerifiedEmail(Email email) => new(CheckVerifiedEmail(email));

    private VerifiedEmail(string email)
      => Address = email;

    private static string CheckVerifiedEmail(Email email)
    {
        if (email.Status is not EmailStatus.VERIFIED)
        {
            throw new EmailNotVerifiedException(email);
        }

        return email;
    }
}
