using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class InventoryItemService : Interfaces.IInventoryItemService
    {
        private readonly BookWebAppContext _context;
        public InventoryItemService(BookWebAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InventoryItem inventoryItem)
        {
            await _context.InventoryItem.AddAsync(inventoryItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.InventoryItem.FirstOrDefaultAsync(e => e.Id == id);
            _context.InventoryItem.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(int inventoryId)
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

        public async Task<InventoryItem> GetByIdAsync(int id)
        {
            var entity = await _context.InventoryItem.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<InventoryItem> UpdateAsync(int id, InventoryItem newInventoryItem)
        {
            _context.InventoryItem.Update(newInventoryItem);
            await _context.SaveChangesAsync();
            return newInventoryItem;
        }

        public async Task<IEnumerable<InventoryItem>> GetByInventoryIdAsync(int id)
        {
            var entities = await _context.InventoryItem.Where(e => e.InventoryId == id).ToListAsync();
            return entities;
        }

        public async Task DeleteByInventoryIdAsync(int id)
        {
            var entities = await _context.InventoryItem.Where(e => e.InventoryId == id).ToListAsync();
            _context.InventoryItem.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
