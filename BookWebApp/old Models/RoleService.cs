// using BookWebApp.Models;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BookWebApp.Data.Services
// {
//     public class RoleService : Interfaces.IRoleService
//     {
//         private readonly BookWebAppContext _context;
//         public RoleService(BookWebAppContext context)
//         {
//                 _context = context;
//         }
//         public async Task AddAsync(Role role)
//         {
//             await _context.Role.AddAsync(role);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteAsync(int id)
//         {
//             var entity = await _context.Role.FirstOrDefaultAsync(e => e.Id == id);
//             _context.Role.Remove(entity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task<IEnumerable<Role>> GetAllAsync()
//         {
//             var entity = await _context.Role.ToListAsync();
//             return entity;
//         }

//         public async Task<Role> GetByIdAsync(int id)
//         {
//             var entity = await _context.Role.FirstOrDefaultAsync(e => e.Id == id);
//             return entity;
//         }

//         public async Task<Role> GetByValueAsync(string value)
//         {
//             var entity = await _context.Role.FirstOrDefaultAsync(e => e.Value == value);
//             return entity;
//         }

//         public async Task<Role> UpdateAsync(int id, Role newRole)
//         {
//             _context.Role.Update(newRole);
//             await _context.SaveChangesAsync();
//             return newRole;
//         }
//     }
// }
