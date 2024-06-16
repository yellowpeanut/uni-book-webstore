using Application.Data.Enums;
using Application.Models;
using Application.ViewModels;

namespace Application.Data.Utils
{
    public class BookDataHelper
    {
        public static IEnumerable<BookCardViewModel> StickBookDataToBookCardVM(
            ApplicationContext context,
            IEnumerable<BookData> bookData)
        {
            var bookIds = bookData.Select(e => e.Book.Id).ToList();
            var posts = context.Post.Where(e => bookIds.Contains(e.BookId)).ToList().Distinct();
            var userIds = posts.Select(e => e.UserId).ToList();
            var users = context.Users.Where(e => userIds.Contains(e.Id)).ToList();

            BookData bd;
            User user;
            Post pt;

            var entities = new List<BookCardViewModel>() { };
            foreach (var post in posts)
            {
                bd = bookData.Where(b => b.Book.Id == post.BookId).First();
                user = users.Where(u => u.Id == post.UserId).First();
                pt = posts.Where(p => p.UserId == user.Id && p.BookId == bd.Book.Id).First();
                
                entities.Add(new BookCardViewModel()
                {
                    BookData = bookData.Where(b => b.Book.Id == post.BookId).First(),
                    User = users.Where(u => u.Id == post.UserId).First(),
                    Price = pt.Price,
                    ReleaseYear = pt.ReleaseYear
                });
            }
            return entities;
        }
    }
}
