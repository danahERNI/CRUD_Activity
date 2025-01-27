using ItemList.Model.Entities;

namespace ItemList.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<ItemModel>> GetAllItems();
        public Task<ItemModel?> GetItemId(int id);
        public Task<ItemModel> AddItem(ItemModel item);
        public Task<ItemModel?> UpdateItem(int id, ItemModel item);
        public Task<ItemModel> DeleteItem(int id);

    }
}
