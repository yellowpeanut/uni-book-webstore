using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class BookCategoryService : Interfaces.IBookCategoryService
    {
        private readonly BookWebAppContext _context;
        public BookCategoryService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BookCategory bookCategory)
        {
            await _context.BookCategory.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<BookCategory> bookCategories)
        {
            await _context.BookCategory.AddRangeAsync(bookCategories);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bookId, int categoryId)
        {
            var entity = await _context.BookCategory.FirstOrDefaultAsync(e => e.BookId == bookId && e.CategoryId == categoryId);
            _context.BookCategory.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByBookIdAsync(int id)
        {
            var entities = await _context.BookCategory.Where(e => e.BookId == id).ToListAsync();
            _context.BookCategory.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByCategoryIdAsync(int id)
        {
            var entities = await _context.BookCategory.Where(e => e.CategoryId == id).ToListAsync();
            _context.BookCategory.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookCategory>> GetAllAsync()
        {
            var entity = await _context.BookCategory.ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<BookCategory>> GetByBookIdAsync(int id)
        {
            var entities = await _context.BookCategory.Where(e => e.BookId == id).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<BookCategory>> GetByCategoryIdAsync(int id)
        {
            var entities = await _context.BookCategory.Where(e => e.CategoryId == id).ToListAsync();
            return entities;
        }

        public async Task<BookCategory> GetByIdAsync(int bookId, int categoryId)
        {
            var entity = await _context.BookCategory.FirstOrDefaultAsync(e => e.BookId == bookId && e.CategoryId == categoryId);
            return entity;
        }

/*        public async Task<BookCategory> UpdateAsync(int bookId, int categoryId, BookCategory newBookCategory)
        {
            throw new System.NotImplementedException();
        }*/
    }
}
