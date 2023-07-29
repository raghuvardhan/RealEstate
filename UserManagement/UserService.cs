using System;
using UserManagement.Models;

namespace UserManagement
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            // Hash the password, validate the data, etc.

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            // Hash the password and check if a user with the given username and password hash exists
            User user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                // Compare password hash
            }
            return user;
        }

        public async Task<User> GetProfile(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> UpdateProfile(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }

}

