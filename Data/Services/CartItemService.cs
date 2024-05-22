using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class CartItemService
    {
        private readonly ApplicationContext _context;
        public CartItemService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(CartItem cartItem)
        {
            await _context.CartItem.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var entity = await _context.CartItem.FirstOrDefaultAsync(e => e.Id == id);
            _context.CartItem.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByCartIdAsync(ulong id)
        {
            var entities = await _context.CartItem.Where(e => e.CartId == id).ToListAsync();
            _context.CartItem.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            var entity = await _context.CartItem.ToListAsync();
            return entity;
        }

        public async Task<CartItem> GetByIdAsync(ulong id)
        {
            var entity = await _context.CartItem.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<CartItem> UpdateAsync(ulong id, CartItem newCartItem)
        {
            _context.CartItem.Update(newCartItem);
            await _context.SaveChangesAsync();
            return newCartItem;
        }

        public async Task<IEnumerable<CartItem>> GetByCartIdAsync(ulong id)
        {
            var entities = await _context.CartItem.Where(e => e.CartId == id).ToListAsync();
            return entities;
        }
    }
}
