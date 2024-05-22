using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class BookCategoryService
    {
        private readonly ApplicationContext _context;
        public BookCategoryService(ApplicationContext context)
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

        public async Task DeleteAsync(ulong bookId, int categoryId)
        {
            var entity = await _context.BookCategory.FirstOrDefaultAsync(e => e.BookId == bookId && e.CategoryId == categoryId);
            _context.BookCategory.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByBookIdAsync(ulong id)
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

        public async Task<IEnumerable<BookCategory>> GetByBookIdAsync(ulong id)
        {
            var entities = await _context.BookCategory.Where(e => e.BookId == id).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<BookCategory>> GetByCategoryIdAsync(int id)
        {
            var entities = await _context.BookCategory.Where(e => e.CategoryId == id).ToListAsync();
            return entities;
        }

        public async Task<BookCategory> GetByIdAsync(ulong id)
        {
            var entity = await _context.BookCategory.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<BookCategory> UpdateAsync(ulong bookId, int categoryId, BookCategory newBookCategory)
        {
            _context.BookCategory.Update(newBookCategory);
            await _context.SaveChangesAsync();
            return newBookCategory;
        }
    }
}
