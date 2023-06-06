/*using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class BookInfoService : Interfaces.IBookInfoService
    {
        private readonly BookWebAppContext _context;
        public BookInfoService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BookInfo bookInfo)
        {
            await _context.BookInfo.AddAsync(bookInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.BookInfo.FirstOrDefaultAsync(e => e.BookId == id);
            _context.BookInfo.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookInfo>> GetAllAsync()
        {
            var entity = await _context.BookInfo.ToListAsync();
            return entity;
        }

        public async Task<BookInfo> GetByIdAsync(int id)
        {
            var entity = await _context.BookInfo.FirstOrDefaultAsync(e => e.BookId == id);
            return entity;
        }

        public async Task<BookInfo> UpdateAsync(int id, BookInfo newBookInfo)
        {
            _context.BookInfo.Update(newBookInfo);
            await _context.SaveChangesAsync();
            return newBookInfo;
        }
    }
}
*/