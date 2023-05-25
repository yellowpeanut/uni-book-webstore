using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class CartItemService : Interfaces.ICartItemService
    {
        private readonly BookWebAppContext _context;
        public CartItemService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(CartItem cartItem)
        {
            await _context.CartItem.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CartItem.FirstOrDefaultAsync(e => e.Id == id);
            _context.CartItem.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByCartIdAsync(int id)
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

        public async Task<CartItem> GetByIdAsync(int id)
        {
            var entity = await _context.CartItem.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<CartItem> UpdateAsync(int id, CartItem newCartItem)
        {
            _context.CartItem.Update(newCartItem);
            await _context.SaveChangesAsync();
            return newCartItem;
        }

        public async Task<IEnumerable<CartItem>> GetByCartIdAsync(int id)
        {
            var entities = await _context.CartItem.Where(e => e.CartId == id).ToListAsync();
            return entities;
        }
    }
}
