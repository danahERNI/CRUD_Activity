namespace ItemList.Model.Entities
{
    public class ItemModel
    {
        public int Id { get; set; }
        public long Serial { get; set; }
        public required string ItemName { get; set; }
        public string? Description { get; set; }
        public required string Category { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
