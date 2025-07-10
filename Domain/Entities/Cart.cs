namespace FoodCart.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        private readonly List<CartItem> _items = new();
        public IReadOnlyList<CartItem> Items => _items;

        public void AddItem(Product product, int quantity)
        {
            var existing = _items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existing != null)
            {
                existing.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }
        
        public decimal Total => _items.Sum(i => i.TotalPrice);
    }
}
