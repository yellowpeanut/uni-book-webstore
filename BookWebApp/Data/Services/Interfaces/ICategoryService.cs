using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByValueAsync(string value);
        Task<IEnumerable<Book>> GetBooksAsync(int id);
        Task AddAsync(Category category);
        Task<Category> UpdateAsync(int id, Category newCategory);
        Task DeleteAsync(int id);
    }
}
