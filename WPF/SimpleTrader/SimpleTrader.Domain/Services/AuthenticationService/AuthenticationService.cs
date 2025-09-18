using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService accountService;
        IPasswordHasher hasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher hasher)
        {
            this.accountService = accountService;
            this.hasher = hasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account stored = await accountService.GetByUsername(username);

            PasswordVerificationResult result = hasher.VerifyHashedPassword(stored.AccountHolder.PasswordHash, password);

            if (result != PasswordVerificationResult.Success) throw new InvalidPasswordException(username, password);

            return stored;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword) result = RegistrationResult.PasswordDoNotMatch;

            Account stored = await accountService.GetByEmail(email);

            if (stored is not null) result = RegistrationResult.EmailAlreadyExists;

            stored = await accountService.GetByUsername(username);

            if (stored is not null) result = RegistrationResult.UsernameAlreadyExists;

            if (result == RegistrationResult.Success)
            {
                User user = new()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hasher.HashPassword(password)
                };

                Account account = new()
                {
                    AccountHolder = user
                };

                await accountService.Create(account);
            }

            return result;
        }
    }
}
