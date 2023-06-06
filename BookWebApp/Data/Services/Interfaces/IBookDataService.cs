using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IBookDataService
    {
        Task<IEnumerable<BookData>> GetAllAsync();
        Task<BookData> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync(int id);
        Task AddAsync(BookData bookData);
        Task AddRangeAsync(IEnumerable<BookData> bookData);
        Task<BookData> UpdateAsync(int id, BookData newBookData);
        Task DeleteAsync(int id);
    }
}
