namespace Dominio.Application.Features.Accounts.Types;

public class Username
{
    public string Value { get; private set; }

    public static implicit operator string(Username email) => email.Value;

    public static implicit operator Username(string email) => new(email);

    public Username(string username)
    {
        Value = username
                  .Trim()
                  .ToLower()
                  .Replace(" ", "_");
    }
}
