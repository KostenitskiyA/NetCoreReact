using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class AccountService : IAccountService
    {
        private ApplicationContext _context;

        public AccountService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> GetAccountAsync(int id)
        {
            try
            {
                var foundAccount = await _context.Accounts.SingleOrDefaultAsync(u => u.Id == id);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                foundAccount.User = null;

                return foundAccount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAccountAsync()
        {
            try
            {
                var foundAccounts = await _context.Accounts.ToListAsync();

                if (foundAccounts == null)
                    throw new Exception("Аккаунты не найдены");

                foreach (var account in foundAccounts)
                    account.User = null;

                return foundAccounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
