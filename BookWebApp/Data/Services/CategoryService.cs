using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class CategoryService : Interfaces.ICategoryService
    {
        private readonly BookWebAppContext _context;
        public CategoryService(BookWebAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Category.FirstOrDefaultAsync(e => e.Id == id);
            _context.Category.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var entity = await _context.Category.ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int id)
        {
            var bcs = new BookCategoryService(_context);
            var categoryIds = await bcs.GetByCategoryIdAsync(id);
            var entities = categoryIds.Select(e => e.Book);
            return entities;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity = await _context.Category.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<Category> UpdateAsync(int id, Category newCategory)
        {
            _context.Category.Update(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }
    }
}
