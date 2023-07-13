using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class UserCartService : Interfaces.IUserCartService
    {
        private readonly BookWebAppContext _context;
        public UserCartService(BookWebAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserCart userCart)
        {
            await _context.UserCart.AddAsync(userCart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CartItemService ciServ = new CartItemService(_context);
            await ciServ.DeleteByCartIdAsync(id);
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.Id == id);
            _context.UserCart.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserCart>> GetAllAsync()
        {
            var entity = await _context.UserCart.ToListAsync();
            return entity;
        }

        public async Task<UserCart> GetByIdAsync(int id)
        {
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<UserCart> GetByUserIdAsync(string id)
        {
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.UserId == id);
            return entity;
        }

        public async Task<UserCart> UpdateAsync(int id, UserCart newUserCart)
        {
            _context.UserCart.Update(newUserCart);
            await _context.SaveChangesAsync();
            return newUserCart;
        }
    }
}
