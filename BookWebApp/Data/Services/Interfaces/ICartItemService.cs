using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem> GetByIdAsync(int id);
        Task<IEnumerable<CartItem>> GetByCartIdAsync(int id);
        Task AddAsync(CartItem cartItem);
        Task<CartItem> UpdateAsync(int id, CartItem newCartItem);
        Task DeleteAsync(int id);
        Task DeleteByCartIdAsync(int id);
    }
}
