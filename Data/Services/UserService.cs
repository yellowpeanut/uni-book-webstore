using Application.Data.Enums;
using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Services
{
    public class UserService
    {
        private readonly ApplicationContext _context;
        private readonly UserInventoryService _userInventoryService;
        private readonly UserCartService _userCartService;
        public UserService(ApplicationContext context, UserInventoryService userInventoryService, UserCartService userCartService)
        {
            _context = context;
            _userInventoryService = userInventoryService;
            _userCartService = userCartService;
        }
        public async Task<bool> AddAsync(User user, string role, UserManager<User> userManager)
        {
            var result = await userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                await _context.SaveChangesAsync();

                UserInventory inventory = new UserInventory() { UserId = user.Id, User = user };
                UserCart cart = new UserCart() { UserId = user.Id, User = user };
                await _userInventoryService.AddAsync(inventory);
                await _userCartService.AddAsync(cart);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteAsync(string id, UserManager<User> userManager)
        {
            await _userInventoryService.DeleteAsync(
                (await _userInventoryService.GetByUserIdAsync(id)).Id);
            await _userCartService.DeleteAsync(
                (await _userCartService.GetByUserIdAsync(id)).Id);
            var entity = await userManager.FindByIdAsync(id);

            Roles roleStruct = new Roles();
            var roles = roleStruct.GetType().GetFields();
            foreach (var r in roles)
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
