using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class UserInventoryService
    {
        private readonly ApplicationContext _context;
        private readonly InventoryItemService _inventoryItemService;
        public UserInventoryService(ApplicationContext context, InventoryItemService inventoryItemService)
        {
            _context = context;
            _inventoryItemService = inventoryItemService;
        }
        public async Task AddAsync(UserInventory userInventory)
        {
            await _context.UserInventory.AddAsync(userInventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            await _inventoryItemService.DeleteByInventoryIdAsync(id);
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.Id == id);
            _context.UserInventory.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserInventory>> GetAllAsync()
        {
            var entity = await _context.UserInventory.ToListAsync();
            return entity;
        }

        public async Task<UserInventory> GetByIdAsync(ulong id)
        {
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<UserInventory> GetByUserIdAsync(string id)
        {
            var entity = await _context.UserInventory.FirstOrDefaultAsync(e => e.UserId == id);
            return entity;
        }

        public async Task<UserInventory> UpdateAsync(ulong id, UserInventory newUserInventory)
        {
            _context.UserInventory.Update(newUserInventory);
            await _context.SaveChangesAsync();
            return newUserInventory;
        }
    }
}
