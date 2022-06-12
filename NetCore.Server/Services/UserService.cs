using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class UserService : IUserService
    {
        private ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Account> SignInAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.Authentications.AddAsync(user.Authentication);
                await _context.SaveChangesAsync();

                var createdUser = await _context.Users.Include(u => u.Authentication)
                    .SingleOrDefaultAsync();

                if (createdUser == null)
                    throw new Exception("Не удалось создать пользователя");

                createdUser.Authentication.User = null;

                return createdUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Account> LogInAsync(User user)
        {
            try
            {
                var foundUser = await _context.Users.Include(u => u.Authentication)
                    .SingleOrDefaultAsync(u => u.Authentication.Login == user.Authentication.Login
                                            && u.Authentication.Password == user.Authentication.Password);

                if (foundUser == null)
                    throw new Exception("Пользователь не найден");

                foundUser.Authentication.User = null;

                return foundUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
