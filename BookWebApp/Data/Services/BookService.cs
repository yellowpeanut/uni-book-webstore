using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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

        public async Task AddWithCategoriesAsync(Book book, IEnumerable<string> categoryValues)
        {
            var catServ = new CategoryService(_context);
            var bcServ = new BookCategoryService(_context);

            var bcList = new List<BookCategory>() { };
            Category cat = new Category();

            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();

            book = (await _context.Book.ToListAsync()).OrderBy(x => x.Id).Last();
            foreach (var v in categoryValues)
            {
                if (await catServ.GetByValueAsync(v) == null)
                    await catServ.AddAsync(new Category() { Value = v });
                cat = await catServ.GetByValueAsync(v);
                bcList.Append(new BookCategory()
                {
                    BookId = book.Id,
                    CategoryId = cat.Id,
                    Book = book,
                    Category = cat
                });
            }
            await bcServ.AddRangeAsync(bcList);
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

        public async Task DeleteAsync(int id)
        {
            var bcs = new BookCategoryService(_context);
            await bcs.DeleteByBookIdAsync(id);
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
