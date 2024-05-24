using Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data.Services
{
    public class BookService
    {
        private readonly ApplicationContext _context;
        private readonly CategoryService _categoryService;
        private readonly BookCategoryService _bookCategoryService;
        public BookService(ApplicationContext context, CategoryService categoryService, BookCategoryService bookCategoryService)
        {
            _context = context;
            _categoryService = categoryService;
            _bookCategoryService = bookCategoryService;
        }
        public async Task AddAsync(Book book)
        {
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task AddWithCategoriesAsync(Book book, IEnumerable<string> categoryValues)
        {
            var bcList = new List<BookCategory>() { };
            Category cat = new Category();

            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();

            book = (await _context.Book.ToListAsync()).OrderBy(x => x.Id).Last();
            foreach (var v in categoryValues)
            {
                if (await _categoryService.GetByValueAsync(v) == null)
                    await _categoryService.AddAsync(new Category() { Value = v });
                cat = await _categoryService.GetByValueAsync(v);
                BookCategory bc = new BookCategory()
                {
                    BookId = book.Id,
                    CategoryId = cat.Id,
                    Book = book,
                    Category = cat
                };
                bcList.Add(bc);
            }
            await _bookCategoryService.AddRangeAsync(bcList);
            // var ctest = await _bookCategoryService.GetByBookIdAsync(book.Id);
            // var ctest2 = await _bookCategoryService.GetAllAsync();
        }

        public async Task AddWithCategoriesAsync(Book book, IEnumerable<Category> categories)
        {
            var bcServ = new BookCategoryService(_context);
            var bcList = new List<BookCategory>() { };

            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();

            var bk = await _context.Book.OrderBy(x => x.Id).LastAsync();
            foreach (var cat in categories)
            {
                bcList.Append(new BookCategory()
                {
                    BookId = bk.Id,
                    CategoryId = cat.Id,
                    Book = bk,
                    Category = cat
                });
            }
            await bcServ.AddRangeAsync(bcList);
        }

        public async Task DeleteAsync(ulong id)
        {
            await _bookCategoryService.DeleteByBookIdAsync(id);
            var entity = await _context.Book.FirstOrDefaultAsync(e => e.Id == id);
            _context.Book.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var entity = await _context.Book.ToListAsync();
            return entity;
        }

        public async Task<Book> GetByIdAsync(ulong id)
        {
            var entity = await _context.Book.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<Book>> GetByIdsAsync(IEnumerable<ulong> ids)
        {
            var entities = await _context.Book.Where(e => ids.Contains(e.Id)).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(ulong id)
        {
            var bookCategoryList = await _bookCategoryService.GetByBookIdAsync(id);
            var entities = bookCategoryList.Select(e => e.Category);
            return entities;
        }

        public async Task<Book> UpdateAsync(ulong id, Book newBook)
        {
            _context.Book.Update(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}
