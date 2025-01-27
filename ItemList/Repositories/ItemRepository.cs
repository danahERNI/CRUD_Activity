﻿using System.Threading.Tasks;
using ItemList.Data;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItemList.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            item.DateAdded = DateTime.Now;
            _context.ItemModels.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<ItemModel> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            var itemList = await _context.ItemModels.ToListAsync();
            return itemList;
        }

        public async Task<ItemModel> GetItemId(int id)
        {
            var getItem = await _context.ItemModels.FindAsync(id);
            return getItem;
        }

        public async Task<ItemModel> UpdateItem(ItemModel item)
        {
            var updatedItem = ;
            return updatedItem;
        }
    }
}
