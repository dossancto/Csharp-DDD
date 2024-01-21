using Dominio.Application.Features.Accounts.Types;

namespace Dominio.Application.Features.Accounts.UseCases;

public class SendEmailConfirmationUseCase
{
    public string Execute(UnverifiedEmail email)
    {
        // Perform logic to send a confirmation code
        var code = "<random-code>";
        return code;
    }
}

