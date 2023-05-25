using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IInventoryItemService
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<InventoryItem> GetByIdAsync(int id);
        Task<IEnumerable<InventoryItem>> GetByInventoryIdAsync(int id);
        Task AddAsync(InventoryItem inventoryItem);
        Task<InventoryItem> UpdateAsync(int id, InventoryItem newInventoryItem);
        Task DeleteAsync(int id);
        Task DeleteByInventoryIdAsync(int id);
    }
}

