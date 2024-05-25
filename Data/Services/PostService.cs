using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class PostService
    {
        private readonly ApplicationContext _context;
        public PostService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var entity = await _context.Post.FirstOrDefaultAsync(e => e.Id == id);
            _context.Post.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllByUserIdAsync(string userId)
        {
            var entities = await _context.Post.Where(e => e.UserId == userId).ToListAsync();
            _context.Post.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var entity = await _context.Post.ToListAsync();
            return entity;
        }

        public async Task<Post> GetByIdAsync(ulong id)
        {
            var entity = await _context.Post.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<Post> GetByUserIdAndBookIdAsync(string userId, ulong bookId)
        {
            var entity = await _context.Post.FirstOrDefaultAsync(e => e.UserId == userId && e.BookId == bookId);
            return entity;
        }

        public async Task<Post> UpdateAsync(ulong id, Post newPost)
        {
            _context.Post.Update(newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }

        public async Task<IEnumerable<Post>> GetAllByUserIdAsync(string userId)
        {
            var entities = await _context.Post.Where(e => e.UserId == userId).ToListAsync();
            return entities;
        }
    }
}
