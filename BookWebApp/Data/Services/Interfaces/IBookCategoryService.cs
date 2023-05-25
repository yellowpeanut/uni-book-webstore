using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int bookId, int categoryId);
        Task<IEnumerable<BookCategory>> GetByBookIdAsync(int id);
        Task<IEnumerable<BookCategory>> GetByCategoryIdAsync(int id);
        Task AddAsync(BookCategory bookCategory);
        //Task<BookCategory> UpdateAsync(int bookId, int categoryId, BookCategory newBookCategory);
        Task DeleteAsync(int bookId, int categoryId);
        Task DeleteByBookIdAsync(int id);
        Task DeleteByCategoryIdAsync(int id);
    }
}

