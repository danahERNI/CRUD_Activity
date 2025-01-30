using ItemList.Model.Entities;

namespace ItemList.Data.DTOs
{
    public class AddItemDTOs
    {
        public required string ItemName { get; set; }
        public string? Description { get; set; }
        public required string Category { get; set; }
        //public Owner Owner { get; set; }
        public int? OwnerId { get; set; }

    }
}
