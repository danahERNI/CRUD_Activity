using ItemList.Model.Entities;

namespace ItemList.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemModel>> GetAllItems(int id);
        Task<ItemModel> GetItemId(int id);
        Task<ItemModel> AddItem(ItemModel item);
        Task<ItemModel> UpdateItem(ItemModel item);
        Task<ItemModel> DeleteItem(int id);

    }
}
