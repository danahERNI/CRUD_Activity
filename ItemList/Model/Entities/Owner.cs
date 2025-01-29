namespace ItemList.Model.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public required string OwnerName { get; set; }
        public required string ContactNumber { get; set; }
        public string? Email { get; set; }

        //items
        public List<ItemModel?>? ItemModel { get; set; }
    }
}
