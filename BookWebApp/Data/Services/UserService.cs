using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class UserService : Interfaces.IUserService
    {
        private readonly BookWebAppContext _context;
        public UserService(BookWebAppContext context)
        {
                _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.User.FirstOrDefaultAsync(e => e.Id == id);
            _context.User.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var entity = await _context.User.ToListAsync();
            return entity;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var entity = await _context.User.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<User> UpdateAsync(int id, User newUser)
        {
            _context.User.Update(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
