using Dominio.Application.Features.Accounts.Types;

namespace Dominio.Application.Features.Accounts.UseCases;

public class ChangeAccountPasswordUseCase
{
    public string Execute(ChangePassword dto)
    {
        // Perform logic to update a password.
        return dto.newPassword;
    }
}

public record ChangePassword(
    VerifiedEmail email,
    string oldPassword,
    string newPassword
    );
