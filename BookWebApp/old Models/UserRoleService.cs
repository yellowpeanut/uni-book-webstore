// using BookWebApp.Models;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BookWebApp.Data.Services
// {
//     public class UserRoleService : Interfaces.IUserRoleService
//     {
//         private readonly BookWebAppContext _context;
//         public UserRoleService(BookWebAppContext context)
//         {
//                 _context = context;
//         }
//         public async Task AddAsync(UserRole userRole)
//         {
//             await _context.UserRole.AddAsync(userRole);
//             await _context.SaveChangesAsync();
//         }

//         public async Task AddRangeAsync(IEnumerable<UserRole> userRoles)
//         {
//             await _context.UserRole.AddRangeAsync(userRoles);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteByUserIdAsync(string id)
//         {
//             var entity = await _context.UserRole.FirstOrDefaultAsync(e => e.Id == id);
//             _context.UserRole.Remove(entity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task<IEnumerable<UserRole>> GetAllAsync()
//         {
//             var entity = await _context.UserRole.ToListAsync();
//             return entity;
//         }

//         public async Task<UserRole> GetByUserIdAsync(string id)
//         {
//             var entity = await _context.UserRole.FirstOrDefaultAsync(e => e.UserId == id);
//             return entity;
//         }

//         public async Task<UserRole> UpdateAsync(string userId, UserRole newUserRole)
//         {
//             string id = (await _context.UserRole.FirstOrDefaultAsync(e => e.UserId == userId)).Id;
//             _context.UserRole.Update(newUserRole);
//             await _context.SaveChangesAsync();
//             return newUserRole;
//         }
//     }
// }
