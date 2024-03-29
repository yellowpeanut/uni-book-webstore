﻿using BookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWebApp.Data.Services.Interfaces
{
    public interface IUserInventoryService
    {
        Task<IEnumerable<UserInventory>> GetAllAsync();
        Task<UserInventory> GetByIdAsync(int id);
        Task<UserInventory> GetByUserIdAsync(string id);
        Task AddAsync(UserInventory userInventory);
        Task<UserInventory> UpdateAsync(int id, UserInventory newUserInventory);
        Task DeleteAsync(int id);
    }
}

