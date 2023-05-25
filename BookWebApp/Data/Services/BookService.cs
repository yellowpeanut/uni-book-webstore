using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class BookService : Interfaces.IBookService
    {
        private readonly BookWebAppContext _context;
        public BookService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Book book)
        {
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Book.FirstOrDefaultAsync(e => e.Id == id);
            _context.Book.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var entity = await _context.Book.ToListAsync();
            return entity;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var entity = await _context.Book.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int id)
        {
            var bcs = new BookCategoryService(_context);
            var categoryIds = await bcs.GetByBookIdAsync(id);
            var entities = categoryIds.Select(e => e.Category);
            return entities;
        }

        public async Task<Book> UpdateAsync(int id, Book newBook)
        {
            _context.Book.Update(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}
