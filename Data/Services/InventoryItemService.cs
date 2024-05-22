using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class InventoryItemService
    {
        private readonly ApplicationContext _context;
        public InventoryItemService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InventoryItem inventoryItem)
        {
            await _context.InventoryItem.AddAsync(inventoryItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var entity = await _context.InventoryItem.FirstOrDefaultAsync(e => e.Id == id);
            _context.InventoryItem.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(ulong inventoryId)
        {
            var entities = await _context.InventoryItem.Where(e => e.InventoryId == inventoryId).ToListAsync();
            _context.InventoryItem.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            var entity = await _context.InventoryItem.ToListAsync();
            return entity;
        }

        public async Task<InventoryItem> GetByIdAsync(ulong id)
        {
            var entity = await _context.InventoryItem.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<InventoryItem> UpdateAsync(ulong id, InventoryItem newInventoryItem)
        {
            _context.InventoryItem.Update(newInventoryItem);
            await _context.SaveChangesAsync();
            return newInventoryItem;
        }

        public async Task<IEnumerable<InventoryItem>> GetByInventoryIdAsync(ulong id)
        {
            var entities = await _context.InventoryItem.Where(e => e.InventoryId == id).ToListAsync();
            return entities;
        }

        public async Task DeleteByInventoryIdAsync(ulong id)
        {
            var entities = await _context.InventoryItem.Where(e => e.InventoryId == id).ToListAsync();
            _context.InventoryItem.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
