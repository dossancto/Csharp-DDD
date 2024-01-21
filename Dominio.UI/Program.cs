using Dominio.Application.Features.Accounts.Entities;
using Dominio.Application.Features.Accounts.UseCases;
using Dominio.Application.Features.Accounts.Exceptions;
using Dominio.Application.Features.Accounts.Types;

Console.WriteLine("Hello, World!\n");

void HandleEmailError(EmailException e)
{
    var msg = e switch
    {
        EmailNotVerifiedException => "Your email is not verified, please check your inbox.",
        _ => e.Message
    };

    Console.WriteLine(msg);
}

void EmailAdd()
{
    var user = new Account
    {
        Email = new("teste@teste.com")
        {
            Status = EmailStatus.UNVERIFIED
        }
    };

    var changePassword = new ChangePassword(user.Email, "a", "b");
    var newPassword = new ChangeAccountPasswordUseCase().Execute(changePassword);

    Console.WriteLine($"Your password was updated. the new one is '{newPassword}'");
}

try
{
    EmailAdd();
}
catch (EmailException e)
{
    HandleEmailError(e);
}
