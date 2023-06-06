using System.Collections.Generic;


namespace BookWebApp.Models
{
    public class BookData
    {
        public BookData(Book book, IEnumerable<string> categoryValues)
        {
            Book = book;
            CategoryValues = categoryValues;
        }
        public BookData(Book book, IEnumerable<Category> categories)
        {
            Book = book;
            Categories = categories;
        }
        public BookData(Book book, IEnumerable<string> categoryValues, IEnumerable<Category> categories)
        {
            Book = book;
            CategoryValues = categoryValues;
            Categories = categories;
        }
        public Book Book { get; set; }

        public IEnumerable<string> CategoryValues { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
