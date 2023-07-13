using BookWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<bool> AddAsync(User user, string role, UserManager<User> userManager);
        Task<User> UpdateAsync(string id, User newUser, UserManager<User> userManager);
        Task DeleteAsync(string id, UserManager<User> userManager);
    }
}
