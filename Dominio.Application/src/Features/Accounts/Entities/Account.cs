using Dominio.Application.Features.Accounts.Types;

namespace Dominio.Application.Features.Accounts.Entities;

public class Account
{
    public Email Email { get; set; } = default!;

    public override string ToString()
        => $"Email => {Email.Address}";
}
