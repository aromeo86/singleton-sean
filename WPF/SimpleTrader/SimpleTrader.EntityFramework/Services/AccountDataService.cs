using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly SimpleTraderDbContextFactory dcFactory;
        private readonly NonQueryDataService<Account> nonQueryDataService;

        public AccountDataService(SimpleTraderDbContextFactory dcFactory) => this.dcFactory = dcFactory;

        public async Task<Account> Create(Account entity) => await nonQueryDataService.Create(entity);

        public async Task<bool> Delete(int id)
        {
            await nonQueryDataService.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            return await dc.Accounts.Include(a => a.AssetTransactions)
                                    .Include(a => a.AccountHolder)
                                    .ToListAsync();
        }

        public async Task<Account> GetByEmail(string email)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            return await dc.Accounts.Include(a => a.AssetTransactions)
                                    .Include(a => a.AccountHolder)
                                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
        }

        public async Task<Account> GetById(int id)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            return await dc.Accounts.Include(a => a.AssetTransactions)
                                    .Include(a => a.AccountHolder)
                                    .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<Account> GetByUsername(string username)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            return await dc.Accounts.Include(a => a.AssetTransactions)
                                    .Include(a => a.AccountHolder)
                                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
        }

        public async Task<Account> Update(int id, Account entity) => await nonQueryDataService.Update(id, entity);
    }
}
