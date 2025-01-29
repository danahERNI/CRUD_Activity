using System.Threading.Tasks;
using AutoMapper;
using ItemList.Data;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItemList.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            item.DateAdded = DateTime.Now;
            _context.ItemModels.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<ItemModel?> DeleteItem(int id)
        {
            var item = await _context.ItemModels.FindAsync(id);
            if (item == null) 
            {
                return null;
            }
            _context.ItemModels.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            var itemList = await _context.ItemModels.Include(o => o.Owner)
                                  .Where(o => o.Owner != null && o.Owner.OwnerId == o.OwnerId) 
                                  .ToListAsync();
            return itemList;
        }

        public async Task<ItemModel?> GetItemId(int id)
        {
            var getItem = await _context.ItemModels.FindAsync(id);
            return getItem;
        }

        public async Task<ItemModel?> UpdateItem(int id, ItemModel item)
        {
            var currentItem = await _context.ItemModels.FindAsync(id);
            if (currentItem == null) 
            {
                throw new KeyNotFoundException("No item found.");  
            }
            currentItem.ItemName = item.ItemName;
            currentItem.Description = item.Description;
            currentItem.Category = item.Category;
            currentItem.OwnerId = item.OwnerId;
            //item.DateAdded = currentItem.DateAdded;
            //item.OwnerId =  currentItem.OwnerId;
            //_mapper.Map(item, currentItem);

            await _context.SaveChangesAsync();
            return currentItem;
        }
    }
}
