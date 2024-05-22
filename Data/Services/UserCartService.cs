using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class UserCartService
    {
        private readonly ApplicationContext _context;
        private readonly CartItemService _cartItemService;
        public UserCartService(ApplicationContext context, CartItemService cartItemService)
        {
            _context = context;
            _cartItemService = cartItemService;
        }

        public async Task AddAsync(UserCart userCart)
        {
            await _context.UserCart.AddAsync(userCart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            await _cartItemService.DeleteByCartIdAsync(id);
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.Id == id);
            _context.UserCart.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserCart>> GetAllAsync()
        {
            var entity = await _context.UserCart.ToListAsync();
            return entity;
        }

        public async Task<UserCart> GetByIdAsync(ulong id)
        {
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<UserCart> GetByUserIdAsync(string id)
        {
            var entity = await _context.UserCart.FirstOrDefaultAsync(e => e.UserId == id);
            return entity;
        }

        public async Task<UserCart> UpdateAsync(ulong id, UserCart newUserCart)
        {
            _context.UserCart.Update(newUserCart);
            await _context.SaveChangesAsync();
            return newUserCart;
        }
    }
}
