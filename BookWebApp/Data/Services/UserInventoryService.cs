using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class UserInventoryService : Interfaces.IUserInventoryService
    {
        private readonly BookWebAppContext _context;
        public UserInventoryService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UserInventory userInventory)
        {
            await _context.UserInventory.AddAsync(userInventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            InventoryItemService iiServ = new InventoryItemService(_context);
            await iiServ.DeleteByInventoryIdAsync(id);
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.Id == id);
            _context.UserInventory.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserInventory>> GetAllAsync()
        {
            var entity = await _context.UserInventory.ToListAsync();
            return entity;
        }

        public async Task<UserInventory> GetByIdAsync(int id)
        {
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<UserInventory> GetByUserIdAsync(int id)
        {
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.UserId == id);
            return entity;
        }

        public async Task<UserInventory> UpdateAsync(int id, UserInventory newUserInventory)
        {
            _context.UserInventory.Update(newUserInventory);
            await _context.SaveChangesAsync();
            return newUserInventory;
        }
    }
}
