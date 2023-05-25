using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IBookInfoService
    {
        Task<IEnumerable<BookInfo>> GetAllAsync();
        Task<BookInfo> GetByIdAsync(int id);
        Task AddAsync(BookInfo bookInfo);
        Task<BookInfo> UpdateAsync(int id, BookInfo newBookInfo);
        Task DeleteAsync(int id);
    }
}

