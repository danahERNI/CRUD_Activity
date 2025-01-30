using ItemList.Data.DTOs;

namespace ItemList.Model.Entities
{
    public class ItemModel
    {
        public int Id { get; set; }
        public required string ItemName { get; set; }
        public string? Description { get; set; }
        public required string Category { get; set; }
        public DateTime? DateAdded { get; set; }

        //// owner;
        //public Owner? Owner { get; set; }
        public int? OwnerId { get; set; }

    }
}
