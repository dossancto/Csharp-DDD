using Dominio.Application.Features.Accounts.Types;

namespace Dominio.Application.Features.Accounts.UseCases;

public class SendAccountMessageUseCase
{
    public string Execute(SendMessage dto)
    {
        return $"{dto.From.Value} - {dto.To.Value} [ {dto.Message} ]";
    }
}

public record SendMessage(
    Username From,
    Username To,
    string Message
    );
