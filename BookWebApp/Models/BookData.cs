using System.Collections.Generic;


namespace BookWebApp.Models
{
    public class BookData
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int StorageQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Image { get; set; }

        public IEnumerable<string> CategoryValues { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
