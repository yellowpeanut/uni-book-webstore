using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync(int id);
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(int id, Book newBook);
        Task DeleteAsync(int id);
    }
}

