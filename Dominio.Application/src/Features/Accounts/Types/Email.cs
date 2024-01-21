using System.Text.RegularExpressions;
using Dominio.Application.Features.Accounts.Exceptions;

namespace Dominio.Application.Features.Accounts.Types;

public class Email
{
    public string Address { get; private set; }
    public EmailStatus Status { get; set; }

    public static implicit operator string(Email email) => email.Address;

    public static implicit operator Email(string email) => new(email);

    public Email(string address)
    {
        Address = GetValidEmailAddress(address);
    }

    private static string GetValidEmailAddress(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new EmailException("Email adderss cannot be empty");
        }

        if (!ValidFormat(email))
        {
            throw new EmailException("Email adderss not valid");
        }

        return email.Trim().ToLower();
    }

    private static bool ValidFormat(string email)
    {
        string regexPattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        Regex regex = new Regex(regexPattern);
        return regex.IsMatch(email);
    }

}

