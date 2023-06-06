using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class BookDataService : Interfaces.IBookDataService
    {
        private readonly BookWebAppContext _context;
        public BookDataService(BookWebAppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BookData bookData)
        {
            BookService bServ = new BookService(_context);
            if (bookData.Categories.Count() > 0)
                await bServ.AddWithCategoriesAsync(bookData.Book, bookData.Categories);
            else
                await bServ.AddWithCategoriesAsync(bookData.Book, bookData.CategoryValues);
        }

        public async Task AddRangeAsync(IEnumerable<BookData> bookData)
        {
            foreach (var bd in bookData)
            {
                await AddAsync(bd);
            }
        }

        public async Task DeleteAsync(int id)
        {
            BookService bServ = new BookService(_context);
            await bServ.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookData>> GetAllAsync()
        {
            BookService bServ = new BookService(_context);
            BookCategoryService bcServ = new BookCategoryService(_context);
            List<Book> books = (await bServ.GetAllAsync()).ToList();
            IEnumerable<BookCategory> bookCategories = await bcServ.GetAllAsync();
            IEnumerable<Category> categories;
            IEnumerable<BookData> entities = new List<BookData>() { };
            foreach (var book in books)
            {
                categories = bookCategories.Where(e => e.BookId == book.Id)
                    .Select(x => x.Category);
                entities.Append(new BookData(
                    book,
                    categories.Select(e => e.Value),
                    categories
                    ));
            }
            return entities;
        }

        public async Task<BookData> GetByIdAsync(int id)
        {
            BookService bServ = new BookService(_context);
            Book book = await bServ.GetByIdAsync(id);
            IEnumerable<Category> categories = await bServ.GetCategoriesAsync(id);
            BookData bookData = new BookData(
                book,
                categories.Select(e => e.Value),
                categories);

            return bookData;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int id)
        {
            BookService bServ = new BookService(_context);
            var entities = await bServ.GetCategoriesAsync(id);
            return entities;
        }

        public async Task<BookData> UpdateAsync(int id, BookData newBookData)
        {
            BookService bServ = new BookService(_context);
            BookCategoryService bcServ = new BookCategoryService(_context);

            await bServ.UpdateAsync(id, newBookData.Book);
            var categories = await bServ.GetCategoriesAsync(id);
            if (!Enumerable.SequenceEqual(categories, newBookData.Categories))
            {
                await bcServ.DeleteByBookIdAsync(id);
                foreach (var cat in newBookData.Categories)
                {
                    await bcServ.AddAsync(new BookCategory()
                    {
                        BookId = id,
                        Book = newBookData.Book,
                        CategoryId = cat.Id,
                        Category = cat
                    });
                }
            }

            return newBookData;
        }
    }
}
