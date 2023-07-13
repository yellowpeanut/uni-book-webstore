using BookWebApp.Models;
using BookWebApp.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services
{
    public class UserService : Interfaces.IUserService
    {
        private readonly BookWebAppContext _context;
        public UserService(BookWebAppContext context)
        {
                _context = context;
        }
        public async Task<bool> AddAsync(User user, string role, UserManager<User> userManager)
        {
            UserInventoryService uiServ = new UserInventoryService(_context);
            UserCartService ucServ = new UserCartService(_context);
            // UserRoleService urServ = new UserRoleService(_context);

            // UserRole userRole = new UserRole(){  UserId = user.Id, Role = role };

            // await _context.User.AddAsync(user);

            var result = await userManager.CreateAsync(user, user.Password);
            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                await _context.SaveChangesAsync();
                
                UserInventory inventory = new UserInventory() { UserId = user.Id, User = user };
                UserCart cart = new UserCart() { UserId = user.Id, User = user };
                await uiServ.AddAsync(inventory);
                await ucServ.AddAsync(cart);

                return true;
            } 
            else
            {
                return false;
            }

            // await urServ.AddAsync(userRole);
        }

        public async Task DeleteAsync(string id, UserManager<User> userManager)
        {
            UserInventoryService uiServ = new UserInventoryService(_context);
            UserCartService ucServ = new UserCartService(_context);
            // UserRoleService urServ = new UserRoleService(_context);

            await uiServ.DeleteAsync(uiServ.GetByUserIdAsync(id).Id);
            await ucServ.DeleteAsync(ucServ.GetByUserIdAsync(id).Id);
            // await urServ.DeleteByUserIdAsync(id);

            // var entity = await _context.User.FirstOrDefaultAsync(e => e.Id == id);
            // _context.User.Remove(entity);
            var entity = await userManager.FindByIdAsync(id);
            // await userManager.RemoveFromRoleAsync(entity, Role.User);
            // await userManager.RemoveFromRoleAsync(entity, Role.Manager);
            // await userManager.RemoveFromRoleAsync(entity, Role.Admin);

            Role roleStruct = new Role();
            var roles = roleStruct.GetType().GetFields();
            foreach(var r in roles)
            {
                 string role = r.GetValue(roleStruct).ToString();
                 await userManager.RemoveFromRoleAsync(entity, role);
            }

            await userManager.DeleteAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var entity = await _context.User.ToListAsync();
            return entity;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var entity = await _context.User.FirstOrDefaultAsync(e => e.Email == email);
            return entity;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var entity = await _context.User.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<User> UpdateAsync(string id, User newUser, UserManager<User> userManager)
        {
            // _context.User.Update(newUser);
            await userManager.UpdateAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
