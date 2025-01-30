using ItemList.Model.Entities;

namespace ItemList.Data.DTOs
{
    public class OwnerDTO
    {
        public required string OwnerName { get; set; }
        public required string ContactNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<ItemModel?>? ItemModels { get; set; } = new List<ItemModel?>();

    }
}
