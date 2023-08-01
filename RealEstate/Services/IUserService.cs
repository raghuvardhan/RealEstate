using System;
using UserManagement.Models;

namespace RealEstate
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(string username, string password);
        Task<User> GetProfile(int userId);
        Task<User> UpdateProfile(User user);
    }
}

