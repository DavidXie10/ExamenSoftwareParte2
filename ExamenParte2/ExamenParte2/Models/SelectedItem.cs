
namespace ExamenParte2.Models {
    public class SelectedItem {
        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }

        public SelectedItem(string description, int price, int quantity) {
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Total = quantity * price;
        }
    }
}