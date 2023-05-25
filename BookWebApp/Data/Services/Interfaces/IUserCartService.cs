using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IUserCartService
    {
        Task<IEnumerable<UserCart>> GetAllAsync();
        Task<UserCart> GetByIdAsync(int id);
        Task AddAsync(UserCart userCart);
        Task<UserCart> UpdateAsync(int id, UserCart newUserCart);
        Task DeleteAsync(int id);
    }
}
