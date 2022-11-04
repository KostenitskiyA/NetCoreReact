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

        public async Task<Account> GetAccountAsync(int accountId)
        {
            try
            {
                var foundAccount = await _context.Accounts
                    .SingleOrDefaultAsync(u => u.Id == accountId);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                return foundAccount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> GetFriendsByAccountAsync(int accountId)
        {
            try
            {
                var foundFriends = await _context.FriendsRelationships
                    .Where(f => f.AccountId == accountId)
                    .Join(_context.Accounts,
                        f => f.FriendId,
                        a => a.Id,
                        (f, a) => new Account()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Avatar = a.Avatar
                        })
                    .ToListAsync();

                if (foundFriends == null)
                    throw new Exception("Друзья не найдены");

                return foundFriends;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> GetAccountsByGroupAsync(int groupId)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Accounts)
                    .SingleOrDefaultAsync(g => g.Id == groupId);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Accounts == null)
                    throw new Exception("Аккаунты не найдены");

                return foundGroup.Accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> SearchAccountsByNameAsync(string searchName)
        {
            try
            {
                var foundAccounts = await _context.Accounts
                    .Where(a => a.Name.Contains(searchName))
                    .ToListAsync();

                if (foundAccounts == null)
                    throw new Exception("Аккаунты не найдены");

                return foundAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> SearchAccountsByNameAsync(string groupId, string searchName)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Accounts)
                    .SingleOrDefaultAsync(g => g.Code == groupId);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Accounts == null)
                    throw new Exception("Аккаунты не найдены");

                if (!String.IsNullOrEmpty(searchName))
                    return foundGroup.Accounts
                        .Where(a => a.Name.Contains(searchName));

                return foundGroup.Accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAvatarAsync(int accountId, string avatar)
        {
            try
            {
                var foundAccount = await _context.Accounts
                    .SingleOrDefaultAsync(a => a.Id == accountId);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                foundAccount.Avatar = avatar;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
