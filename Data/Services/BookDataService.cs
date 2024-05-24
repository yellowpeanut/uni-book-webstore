using Application.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using uni_book_webstore;

namespace Application.Data.Services
{
    public class BookDataService
    {
        private readonly ApplicationContext _context;
        private readonly BookService _bookService;
        private readonly BookCategoryService _bookCategoryService;
        private readonly CategoryService _categoryService;
        public BookDataService(ApplicationContext context, BookService bookService, 
            BookCategoryService bookCategoryService, CategoryService categoryService)
        {
            _context = context;
            _bookService = bookService;
            _bookCategoryService = bookCategoryService;
            _categoryService = categoryService;
        }
        public async Task AddAsync(BookData bookData)
        {
            if (bookData.Categories.Count() > 0)
                await _bookService.AddWithCategoriesAsync(bookData.Book, bookData.Categories);
            else
                await _bookService.AddWithCategoriesAsync(bookData.Book, bookData.CategoryValues);
        }

        public async Task AddRangeAsync(IEnumerable<BookData> bookData)
        {
            foreach (var bd in bookData)
            {
                await AddAsync(bd);
            }
        }

        public async Task DeleteAsync(ulong id)
        {
            await _bookService.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookData>> GetAllAsync()
        {
            List<Book> books = await _context.Book.ToListAsync();
            List<Category> allCategories = await _context.Category.ToListAsync();
            List<BookCategory> bookCategories = await _context.BookCategory.ToListAsync();
            var entities = MergeBooksAndCategories(books, allCategories, bookCategories);
            return entities;
        }

        private List<BookData> MergeBooksAndCategories(
            IEnumerable<Book> books,
            IEnumerable<Category> allCategories,
            IEnumerable<BookCategory> bookCategories)
        {
            List<BookData> entities = new List<BookData>() { };
            List<Category> ctgs;
            foreach (var book in books)
            {
                ctgs = bookCategories.Where(e => e.BookId == book.Id)
                    .Select(x => x.Category).ToList();
                BookData bdata = new BookData(
                    book,
                    ctgs.Select(e => e.Value).ToList(),
                    ctgs
                    );
                entities.Add(bdata);
            }
            return entities;
        }

        public async Task<BookData> GetByIdAsync(ulong id)
        {
            Book book = await _bookService.GetByIdAsync(id);
            IEnumerable<Category> categories = await _bookService.GetCategoriesAsync(id);
            BookData bookData = new BookData(
                book,
                categories.Select(e => e.Value),
                categories);

            return bookData;
        }

        public async Task<IEnumerable<BookData>> GetByIdsAsync(IEnumerable<ulong> ids)
        {
            var books = await _bookService.GetByIdsAsync(ids);
            List<Category> allCategories = await _context.Category.ToListAsync();
            List<BookCategory> bookCategories = await _context.BookCategory.ToListAsync();
            var entities = MergeBooksAndCategories(books, allCategories, bookCategories);

            return entities;
        }

        public async Task<IEnumerable<BookData>> GetByNameAndCategories(string name, IEnumerable<Category>? categories = null)
        {
            List<BookData> entities = new List<BookData>() { };
            List<Category> allCategories = await _context.Category.ToListAsync();
            if (categories is null)
            {
                if (name == string.Empty)
                {
                    return await GetAllAsync();
                }
                else
                {
                    List<Book> books = await _context.Book.Where(b => b.Author.Contains(name)
                        || b.Title.Contains(name)).ToListAsync();
                    List<BookCategory> bookCategories = await _context.BookCategory.ToListAsync();
                    entities = MergeBooksAndCategories(books, allCategories, bookCategories);
                }

            }
            else
            {

                if (name == string.Empty)
                {
                    List<Book> books = await _context.Book.ToListAsync();
                    List<BookCategory> bookCategories = await _context.BookCategory.ToListAsync();
                    List<Category> ctgs;
                    HashSet<Category> givenCategories = categories.ToHashSet();
                    foreach (var book in books)
                    {
                        ctgs = bookCategories.Where(e => e.BookId == book.Id)
                            .Select(x => x.Category).ToList();
                        if (givenCategories.IsSubsetOf(ctgs))
                        {
                            BookData bdata = new BookData(
                                book,
                                ctgs.Select(e => e.Value).ToList(),
                                ctgs
                                );
                            entities.Add(bdata);
                        }
                    }
                }
                else
                {
                    List<Book> books = await _context.Book.Where(b => b.Author.Contains(name)
                        || b.Title.Contains(name)).ToListAsync();
                    List<BookCategory> bookCategories = await _context.BookCategory.ToListAsync();
                    List<Category> ctgs;
                    HashSet<Category> givenCategories = categories.ToHashSet();
                    foreach (var book in books)
                    {
                        ctgs = bookCategories.Where(e => e.BookId == book.Id)
                            .Select(x => x.Category).ToList();
                        if (givenCategories.IsSubsetOf(ctgs))
                        {
                            BookData bdata = new BookData(
                                book,
                                ctgs.Select(e => e.Value).ToList(),
                                ctgs
                                );
                            entities.Add(bdata);
                        }
                    }

                }
            }

            return entities;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(ulong id)
        {
            var entities = await _bookService.GetCategoriesAsync(id);
            return entities;
        }

        public async Task<BookData> UpdateAsync(ulong id, BookData newBookData)
        {
            await _bookService.UpdateAsync(id, newBookData.Book);
            var categories = await _bookService.GetCategoriesAsync(id);
            if (!Enumerable.SequenceEqual(categories, newBookData.Categories))
            {
                await _bookCategoryService.DeleteByBookIdAsync(id);
                foreach (var cat in newBookData.Categories)
                {
                    await _bookCategoryService.AddAsync(new BookCategory()
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
        public async Task<ICollection<BookData>> GetRecommendedItems(string? userId = null)
        {
/*            if (userId == null)
            {
                List<Book> books = await _context.Book.OrderByDescending(x => x.Rating)
                    .Take(Globals.RECOMMENDED_ITEMS_COUNT).ToListAsync();
                List<Category> allCategories = await _context.Category.ToListAsync();
                List<BookCategory> bookCategories = await _context.BookCategory
                    .Where(bc => books.Select(b => b.Id).ToList()
                    .Contains(bc.BookId)).ToListAsync();
                var entities = MergeBooksAndCategories(books, allCategories, bookCategories);
                return entities;
            }*/

            // implement function and uncomment above //

            List<Book> books = await _context.Book.OrderByDescending(x => x.Rating)
                .Take(Globals.RECOMMENDED_ITEMS_COUNT).ToListAsync();
            List<Category> allCategories = await _context.Category.ToListAsync();
            List<BookCategory> bookCategories = await _context.BookCategory
                .Where(bc => books.Select(b => b.Id).ToList()
                .Contains(bc.BookId)).ToListAsync();
            var entities = MergeBooksAndCategories(books, allCategories, bookCategories);
            
            return entities;
        }
    }
}
