using System.Threading.Tasks;
using ItemList.Data;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;

namespace ItemList.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddItem(ItemModel item)
        {
            _context.ItemLists.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;

        }

        public Task<ItemModel> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetAllItems(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> GetItemId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> UpdateItem(ItemModel item)
        {
            throw new NotImplementedException();
        }
    }
}
