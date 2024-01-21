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

object EmailAdd(Account user)
{
    var changePassword = new ChangePassword(user.Email, "my old and weak password", "my new strong password");
    var newPassword = new ChangeAccountPasswordUseCase().Execute(changePassword);

    Console.WriteLine($"Your password was updated. the new one is '{newPassword}'");
    return new();
}

object SendConfirmation(Account user)
{
    Console.WriteLine(new SendEmailConfirmationUseCase().Execute(user.Email));
    return new();
}

var user = new Account
{
    Username = "lu-css",
    Email = new("teste@teste.com")
    {
        Status = EmailStatus.UNVERIFIED
    }
};

List<Func<object>> funcs = [
  () => EmailAdd(user),
  () => SendConfirmation(user),
];

funcs.ForEach(func =>
{
    if (ExceptionWrap.Wrap(func).TryError(out Exception e))
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(Environment.NewLine);
    }
});

Console.WriteLine(new SendAccountMessageUseCase().Execute(new("lu css", "azeite", "Vacilao")));
