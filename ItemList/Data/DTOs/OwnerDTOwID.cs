namespace ItemList.Data.DTOs
{
    public class OwnerDTOwID
    {
        public int OwnerId { get; set; }
        public required string OwnerName { get; set; }
        public required string ContactNumber { get; set; }
        public string? Email { get; set; }

    }
}
