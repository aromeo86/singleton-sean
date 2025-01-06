using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationService
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<Account> Login(string username, string password);
    }
}
