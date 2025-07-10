using FoodCart.Domain.Entities;
using FoodCart.Domain.Repositories;

namespace FoodCart.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private static Cart _cart = new();

        public Cart GetCart() => _cart;

        public void Save(Cart cart) => _cart = cart;
    }
}
