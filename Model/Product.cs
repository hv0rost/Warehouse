
namespace WareHouse.Model
{
    public class Product
    {

        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(int Id, int WarehouseId, string Name, double Price, string Category, int Quantity)
        {
            this.Id = Id;
            this.WarehouseId = WarehouseId;
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
            this.Quantity = Quantity;
        }

    }
}
