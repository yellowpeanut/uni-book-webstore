using BookWebApp.Models;
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
            Book book = new Book()
            {
                Id = bookData.Id,
                Price = bookData.Price,
                StorageQuantity = bookData.StorageQuantity,
                SoldQuantity = bookData.SoldQuantity,
                Rating = bookData.Rating
            };
            BookInfo bookInfo = new BookInfo()
            {
                BookId = bookData.Id,
                Author = bookData.Author,
                Title = bookData.Title,
                ReleaseYear = bookData.ReleaseYear,
                Image = bookData.Image,
                Book = book
            };
            IEnumerable<BookCategory> bookCategories = new List<BookCategory>() { };
            foreach (var category in bookData.Categories) 
            {
                bookCategories.Append(new BookCategory()
                {
                    BookId = bookData.Id,
                    CategoryId = category.Id,
                    Book = book,
                    Category = category
                });
            }
            BookService bServ = new BookService(_context);
            BookInfoService biServ = new BookInfoService(_context);
            BookCategoryService bcServ = new BookCategoryService(_context);
            await bServ.AddAsync(book);
            await biServ.AddAsync(bookInfo);
            await bcServ.AddRangeAsync(bookCategories);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            BookService bServ = new BookService(_context);
            BookInfoService biServ = new BookInfoService(_context);
            BookCategoryService bcServ = new BookCategoryService(_context);
            await bcServ.DeleteByBookIdAsync(id);
            await biServ.DeleteAsync(id);
            await bServ.DeleteAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookData>> GetAllAsync()
        {
            BookService bServ = new BookService(_context);
            BookInfoService biServ = new BookInfoService(_context);
            BookCategoryService bcServ = new BookCategoryService(_context);
            List<Book> books = (await bServ.GetAllAsync()).ToList();
            List<BookInfo> bookInfos = (await biServ.GetAllAsync()).ToList();
            IEnumerable<BookCategory> bookCategories = await bcServ.GetAllAsync();
            IEnumerable<Category> categories;
            IEnumerable<BookData> entities = new List<BookData>() {};
            for (int i = 0; i < books.Count(); i++)
            {
                categories = bookCategories.Where(e => e.BookId == books[i].Id)
                    .Select(x => x.Category);
                BookData bookData = new BookData()
                {
                    Id = books[i].Id,
                    Price = books[i].Price,
                    StorageQuantity = books[i].StorageQuantity,
                    SoldQuantity = books[i].SoldQuantity,
                    Rating = books[i].Rating,
                    Author = bookInfos[i].Author,
                    Title = bookInfos[i].Title,
                    ReleaseYear = bookInfos[i].ReleaseYear,
                    Image = bookInfos[i].Image,
                    Categories = categories,
                    CategoryValues = categories.Select(e => e.Value)
                };
                entities.Append(bookData);
            }
            return entities;
        }

        public async Task<BookData> GetByIdAsync(int id)
        {
            BookService bServ = new BookService(_context);
            BookInfoService biServ = new BookInfoService(_context);
            Book book = await bServ.GetByIdAsync(id);
            BookInfo bookInfo = await biServ.GetByIdAsync(id);
            IEnumerable<Category> categories = await bServ.GetCategoriesAsync(id);
            BookData bookData = new BookData()
            {
                Id = book.Id,
                Price = book.Price,
                StorageQuantity = book.StorageQuantity,
                SoldQuantity = book.SoldQuantity,
                Rating = book.Rating,
                Author = bookInfo.Author,
                Title = bookInfo.Title,
                ReleaseYear = bookInfo.ReleaseYear,
                Image = bookInfo.Image,
                Categories = categories,
                CategoryValues = categories.Select(e => e.Value)
            };
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
            BookInfoService biServ = new BookInfoService(_context);
            Book book = new Book()
            {
                Id = newBookData.Id,
                Price = newBookData.Price,
                StorageQuantity = newBookData.StorageQuantity,
                SoldQuantity = newBookData.SoldQuantity,
                Rating = newBookData.Rating
            };
            BookInfo bookInfo = new BookInfo()
            {
                BookId = newBookData.Id,
                Author = newBookData.Author,
                Title = newBookData.Title,
                ReleaseYear = newBookData.ReleaseYear,
                Image = newBookData.Image,
                Book = book
            };
            await bServ.UpdateAsync(id, book);
            await biServ.UpdateAsync(id, bookInfo);
            return newBookData;
        }
    }
}
