using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class CategoryService
    {
        private readonly ApplicationContext _context;
        private readonly BookCategoryService _bookCategoryService;
        public CategoryService(ApplicationContext context, BookCategoryService bookCategoryService)
        {
            _context = context;
            _bookCategoryService = bookCategoryService;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Category> categories)
        {
            await _context.Category.AddRangeAsync(categories);
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
            var bookCategoryList = await _bookCategoryService.GetByCategoryIdAsync(id);
            var entities = bookCategoryList.Select(e => e.Book);
            return entities;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity = await _context.Category.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<Category> GetByValueAsync(string value)
        {
            var entity = await _context.Category.FirstOrDefaultAsync(e => e.Value == value);
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
