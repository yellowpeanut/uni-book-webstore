using Application.Models;
using Application.ViewModels;

namespace Application.Data.Utils
{
    public class PostHelper
    {
        public static IEnumerable<PostViewModel> StickBookDataToPostVM(
            ApplicationContext context,
            IEnumerable<BookData> bookData)
        {
            var bookIds = bookData.Select(e => e.Book.Id).ToList();
            var posts = context.Post.Where(e => bookIds.Contains(e.BookId)).ToList().Distinct();
            var userIds = posts.Select(e => e.UserId).ToList();
            var users = context.Users.Where(e => userIds.Contains(e.Id)).ToList();
            
            var entities = new List<PostViewModel>() { };
            foreach (var post in posts)
            {
                entities.Add(new PostViewModel()
                {
                    BookData = bookData.Where(b => b.Book.Id == post.BookId).First(),
                    User = users.Where(u => u.Id == post.UserId).First()
                });
            }
            return entities;
        }
    }
}
