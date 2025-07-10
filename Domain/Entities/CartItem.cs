namespace FoodCart.Domain.Entities
{
    public class CartItem
    {
        public Product Product { get; }

        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity) 
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public void IncreaseQuantity(int amount) => this.Quantity += amount;

        public decimal TotalPrice => this.Quantity * this.Product.Price;
    }
}
