using Dominio.Application.Features.Accounts.Exceptions;

namespace Dominio.Application.Features.Accounts.Types;

public class UnverifiedEmail
{
    public string Address { get; private set; }

    public static implicit operator UnverifiedEmail(string email) => new(CheckUnverifiedEmail(email));
    public static implicit operator UnverifiedEmail(Email email) => new(CheckUnverifiedEmail(email));

    private UnverifiedEmail(string email)
      => Address = email;

    private static string CheckUnverifiedEmail(Email email)
    {
        if (email.Status is EmailStatus.VERIFIED)
        {
            throw new EmailException("This email is already verified");
        }

        return email;
    }
}

